using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SupplierService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public string OrderProducts(string nProductName, int nAmount)
        {
            return "("+nAmount.ToString() + " " + nProductName + " beställdes först från grossist till lager då saldot inte var tillräckligt)";
        }
    }
}
