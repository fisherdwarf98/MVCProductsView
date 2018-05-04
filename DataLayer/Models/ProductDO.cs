using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProductDO
    {
        //Declaring all the properties for Products
        public int ProductID;
        public string ProductName;
        public string QuantityPerUnit;
        public decimal UnitPrice;
        public Int16 UnitsInStock;
        public Int16 UnitOnOrder;
    }
}
