using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class InventoryPage : System.Web.UI.Page
    {
        // List of textboxes to fetch order data from
        private List<TextBox> textBoxIdList = new List<TextBox>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a table with products fetched from service
            CreateTable();
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            // Reference to service
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            // List of products to send back to service (All ordered objects)
            List<ServiceReference1.Product> returnList = new List<ServiceReference1.Product>();
            // Go through all textboxes and check if number of products ordered > 0
            foreach (TextBox boxInstance in textBoxIdList)
            {
                if (int.Parse(boxInstance.Text)!=0)
                {
                    // Create product to be added to list
                    ServiceReference1.Product productInstance = new ServiceReference1.Product();
                    // Name of product. Is empty since the function receiving them only needs to know id numbers
                    productInstance.Name = ""; 
                    // Id of product, fetch from text boxes
                    productInstance.Id = int.Parse(boxInstance.ID);
                    productInstance.Amount = int.Parse(boxInstance.Text);
                    // Add the product to the list
                    returnList.Add(productInstance);
                    // Set the text box to 0 again
                    boxInstance.Text = "0";
                }
            }
            // Send list of products to service, and get a string with results back (returned as html-formatted list)
            Label2.Text = client.OrderProduct(returnList.ToArray());
            // Empty the table and reload it
            ProductTable.Rows.Clear();
            CreateTable();
        }

        // Create table with products
        private void CreateTable()
        {
            // Reference to inventory service
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            // Retrieve products from inventory
            ServiceReference1.Product[] productList = client.GetInventory();

            // Add headers to table
            // Table row
            TableRow row = new TableRow();
            // Name of product
            TableCell nameCell = new TableCell();
            nameCell.Controls.Add(new LiteralControl("||Product:"));
            // Amount in storage
            TableCell amountCell = new TableCell();
            amountCell.Controls.Add(new LiteralControl("||Storage Amount:"));
            // Text input for order
            TableCell orderCell = new TableCell();
            orderCell.Controls.Add(new LiteralControl("||Order Amount:"));

            // add all cells to row
            row.Cells.Add(nameCell);
            row.Cells.Add(amountCell);
            row.Cells.Add(orderCell);

            // add row to table
            ProductTable.Rows.Add(row);

            // Create a row in the product table, and fill it with data
            foreach (ServiceReference1.Product product in productList)
            {
                // Table row
                row = new TableRow();
                // Name of product
                nameCell = new TableCell();
                nameCell.Controls.Add(new LiteralControl(product.Name));
                // Amount in storage
                amountCell = new TableCell();
                amountCell.Controls.Add(new LiteralControl(product.Amount.ToString()));

                // Text input for order
                orderCell = new TableCell();
                TextBox box = new TextBox();
                box.ID = product.Id.ToString();
                box.Text = "0";
                orderCell.Controls.Add(box);

                // add text box to reference list
                textBoxIdList.Add(box);

                // add all cells to row
                row.Cells.Add(nameCell);
                row.Cells.Add(amountCell);
                row.Cells.Add(orderCell);

                // add row to table
                ProductTable.Rows.Add(row);
            }
        }

    }
}