using System;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductController : Controller
    {

        string connectionString = "Server=DESKTOP-FL99LNQ;Database=ECommerce;Integrated Security=True;";

        [HttpGet("/products")]
        public ActionResult<ProductModel> GetAllProduct()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Products";

                SqlDataReader reader = command.ExecuteReader();
                List<object> Products = new List<object>();
                object[] temporary = new object[7];
                while (reader.Read())
                {
                    reader.GetValues(temporary);
                    Products.Add(temporary.Clone());
                }
                return Ok(Products);
            }
        }
        [HttpGet("/products/{id}")]
        public ActionResult<ProductModel> GetProductById(int id)
        {
            List<object> Products = new List<object>();
            object[] temporary = new object[7];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Products WHERE Id=" + id;
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    reader.GetValues(temporary);
                    Products.Add(temporary.Clone());

                }
                catch (System.Exception ex)
                {
                    return BadRequest("Something wrong -> " + ex.Message);
                }
                connection.Close();
                return Ok(Products);








            }
        }

        [HttpPost]
        public ActionResult<ProductModel> AddProduct(ProductModel productModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

            }

            return new ProductModel
            {

            };
        }


    }
}