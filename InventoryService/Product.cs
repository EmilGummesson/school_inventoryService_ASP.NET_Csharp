using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace InventoryService
{
    [DataContract]
    public class Product
    {
        
        // Constructor
        public Product(string nName, int nID = -1, int nAmount = 0)
        {
            id = nID;
            name = nName;
            amount = nAmount;
        }

        // Product ID
        int id;
        // name of the product
        string name;
        // Amount of product
        int amount;

        // Datamember get/set functions for interface below
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
