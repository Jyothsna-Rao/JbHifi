using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestFulCrudDemo.Controllers;
using RestFulCrudDemo.Models;

namespace CrudTest
{
    [TestClass]
    public class ProductControllerTest
    {

        // using OkNegotiatedContentResult and check whether the return response object has the same Product Id.
        [TestMethod]
        public void GetProductByIdTest()
        {
          
            // var product = new Product { Brand = "Samsung", Description = "This is a Latest Note Series", Id = "1", Model = "Note8" };

            var controller = new ProductsController();
            // Act on Test  
            var response = controller.GetProduct("1");
            var contentResult = response as OkNegotiatedContentResult<Product>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("1", contentResult.Content.Id);


        }

        // Test the response of the action method, when the Product ID is not found 
        [TestMethod]
        public void GetProductByIdNotFound()
        {
            // Set up Prerequisites   
          var controller = new ProductsController();
            
            // Act  
            IHttpActionResult actionResult = controller.GetProduct("100");
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }


       

        }
    }

