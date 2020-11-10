using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace InventoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        // Connection string for database
        private const string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // Fetch inventory from database and return as a list of product instances
        public List<Product> GetInventory()
        {
            // Create connection to sql-server
            SqlConnection con = new SqlConnection(connectionstring);
            // Open connection to sql-server
            con.Open();
            // Query to sent to sql-server
            SqlCommand cmd = new SqlCommand("SELECT * FROM InventoryTable", con);
            // List to store sql results in
            List<Product> productList = new List<Product>();
            // Read results
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Add a product to the list for each returned row
                    productList.Add(new Product(reader.GetSqlValue(1).ToString(), int.Parse(reader.GetSqlValue(0).ToString()), int.Parse(reader.GetSqlValue(2).ToString())));
                }
            }
            // Return the products
            return productList;
        }

        // Order a product from inventory, and return a html-formatted list of results for each product ordered
        public string OrderProduct(List<Product> nProducts)
        {
            // Return message of function
            string message = "<ul>";
            // Create connection to sql-server
            SqlConnection con = new SqlConnection(connectionstring);
            // Open connection to sql-server
            con.Open();

            foreach (Product p in nProducts)
            {
                // Add amount ordered
                message += "<li>" + p.Amount + " ";

                // Query to sent to sql-server, update amount with amount ordered
                SqlCommand cmd = new SqlCommand("UPDATE InventoryTable SET Amount=Amount-"+p.Amount+" WHERE Id = "+p.Id+";", con);
                // Execute query
                cmd.ExecuteNonQuery();

                //Get name of product from database and store in return string
                cmd = new SqlCommand("SELECT Product FROM InventoryTable WHERE Id="+p.Id+";", con);
                // Result from read
                string stringResult = "";
                // Read results
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Add a product to the list for each returned row
                        stringResult = reader.GetSqlValue(0).ToString();
                    }
                }
                // Add results to return string
                message += "st " + stringResult + " beställda från lager.";

                //Get how many remaining products is in database
                cmd = new SqlCommand("SELECT Amount FROM InventoryTable WHERE Id=" + p.Id + ";", con);
                // Result from read
                stringResult = "";
                // Read results
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Add a product to the list for each returned row
                        stringResult = reader.GetSqlValue(0).ToString();
                    }
                }
                // If inventory is empty, order new products
                if (int.Parse(stringResult) <= 0)
                {
                    // reference to supplier service
                    ServiceReference2.Service1Client client = new ServiceReference2.Service1Client();
                    // Order products from supplier, order 10 extra if inventory is empty
                    message += " " + client.OrderProducts(p.Name, ((int.Parse(stringResult) * -1) + 10));

                    // Query to sent to sql-server, update amount with amount ordered
                    cmd = new SqlCommand("UPDATE InventoryTable SET Amount= 10 WHERE Id = " + p.Id + ";", con);
                    // Execute query
                    cmd.ExecuteNonQuery();
                    message += " " + 10 + " kvar i lager.";
                }
                else
                // Add amount left in inventory to string
                message += " " + stringResult + " kvar i lager.";



            }
            // Close html-list
            message += "</ul>";
            // Return list
            return message;
        }

    }
}
