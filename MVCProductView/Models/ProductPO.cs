using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProductView.Models
{
    public class ProductPO
    {
        //Declaring all the properties for Product
        public int ProductID { get; set; }

        [StringLength(40)]
        [Required]
        public string ProductName { get; set; }

        [StringLength(20)]
        [Required]
        public string QuantityPerUnit { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public Int16 UnitsInStock { get; set; }

        [Required]
        public Int16 UnitOnOrder { get; set; }
    }
}