using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ProductDAO
    {
        private string connectionString;
        private string filePath;

        public ProductDAO(string dataConnection, string path)
        {
            connectionString = dataConnection;
            filePath = path;
        }

        //Method that will display all the Products
        public List<ProductDO> ViewAllProducts()
        {
            try
            {
                List<ProductDO> allProducts = new List<ProductDO>();
                //Opens the SQL Connection
                using (SqlConnection viewProductData = new SqlConnection(connectionString))
                {
                    //Creating a new command for a stored procedure
                    SqlCommand enterCommand = new SqlCommand("VIEW_PRODUCTS", viewProductData);
                    enterCommand.CommandType = CommandType.StoredProcedure;
                    viewProductData.Open();

                    //Using a SQLDataAdapter to get the SQL table
                    DataTable productInfo = new DataTable();
                    using (SqlDataAdapter productAdapter = new SqlDataAdapter(enterCommand))
                    {
                        productAdapter.Fill(productInfo);
                        productAdapter.Dispose();
                    }

                    //Putting datarow into the of list of Products
                    foreach(DataRow row in productInfo.Rows)
                    {
                        ProductDO mappedRow = MapAllProducts(row);
                        allProducts.Add(mappedRow);
                    }
                }
                //Returning the updated list of Prodects
                return allProducts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Maps all products from the dataroe and returns the ProductDO
        public ProductDO MapAllProducts(DataRow productRow)
        {
            try
            {
                ProductDO product = new ProductDO();

                //If ProductID is not null, it adds values to the product from the database
                if (productRow["ProductID"] != DBNull.Value)
                {
                    product.ProductID = (int)productRow["ProductID"];
                }
                product.ProductName = productRow["ProductName"].ToString();
                product.QuantityPerUnit = productRow["QuantityPerUnit"].ToString();
                product.UnitPrice = (decimal)productRow["UnitPrice"];
                product.UnitsInStock = (Int16)productRow["UnitsInStock"];
                product.UnitOnOrder = (Int16)productRow["UnitsOnOrder"];

                return product;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
