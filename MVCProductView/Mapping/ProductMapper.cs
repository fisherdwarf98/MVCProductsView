using MVCProductView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Models;

namespace MVCProductView.Mapping
{
    public class ProductMapper
    {
        public static ProductPO  MapDoToPo(ProductDO from)
        {
            ProductPO to = new ProductPO();
            to.ProductID = from.ProductID;
            to.ProductName = from.ProductName;
            to.QuantityPerUnit = from.QuantityPerUnit;
            to.UnitPrice = from.UnitPrice;
            to.UnitsInStock = from.UnitsInStock;
            to.UnitOnOrder = from.UnitOnOrder;

            return to;
        }

        public static List<ProductPO> MapDoToPo(List<ProductDO> from)
        {
            List<ProductPO> to = new List<ProductPO>();

            if (from != null)
            {
                foreach(ProductDO item in from)
                {
                    ProductPO mappeditem = MapDoToPo(item);
                    to.Add(mappeditem);
                }
            }
            return to;
        }

        public static ProductDO MapPoToDo(ProductPO from)
        {
            ProductDO to = new ProductDO();
            to.ProductID = from.ProductID;
            to.ProductName = from.ProductName;
            to.QuantityPerUnit = from.QuantityPerUnit;
            to.UnitPrice = from.UnitPrice;
            to.UnitsInStock = from.UnitsInStock;
            to.UnitOnOrder = from.UnitOnOrder;

            return to;
        }

        public static List<ProductDO> MapPoToDo(List<ProductPO> from)
        {
            List<ProductDO> to = new List<ProductDO>();

            if (from != null)
            {
                foreach (ProductPO item in from)
                {
                    ProductDO mappeditem = MapPoToDo(item);
                    to.Add(mappeditem);
                }
            }
            return to;
        }
    }
}