using DataLayer;
using DataLayer.Models;
using MVCProductView.Mapping;
using MVCProductView.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProductView.Controllers
{
    public class ProductController : Controller
    {
        private ProductDAO dataAccess;
        public ProductController()
        {
            string filePath = ConfigurationManager.AppSettings["logPath"];
            dataAccess = new ProductDAO(connectionString, filePath);
        }

        private static string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            List<ProductPO> mappedItems = new List<ProductPO>();
            try
            {
                List<ProductDO> dataObjects = dataAccess.ViewAllProducts();
                mappedItems = ProductMapper.MapDoToPo(dataObjects);
            }
            catch (Exception ex)
            {

            }

            return View(mappedItems);
        }
    }
}