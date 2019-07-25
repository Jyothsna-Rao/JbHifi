using ConsumeWebApiInMVC.Models;
using ConsumeWebApiInMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebApiInMVC.Controllers
{
    
    public class ProductsController : Controller
    {
        // GET: Product  
       
        public ActionResult GetProducts()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Products");
                response.EnsureSuccessStatusCode();
                List<Models.Product> products = response.Content.ReadAsAsync<List<Models.Product>>().Result;
                ViewBag.Title = "GetProducts";
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public ActionResult GetProduct(int Id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Products/" + Id);
                response.EnsureSuccessStatusCode();
                Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
                ViewBag.Title = "GetProducts";
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Route("Products/{Description}/{Model}/{Brand}")]
        public ActionResult GetProductsByFilter(string description ="" ,string model ="", string brand="" ) 
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                ProductFilter productObj = new ProductFilter { Brand = brand, Description = description, Model = model };
                HttpResponseMessage response = serviceObj.GetResponse("api/Products/GetProductsByFilter" + productObj);
                response.EnsureSuccessStatusCode();
                Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
                ViewBag.Title = "GetProducts";
                return View(products);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet]  
        
        public ActionResult EditProduct(int Id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Products/" + Id);
            response.EnsureSuccessStatusCode();
            Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
            ViewBag.Title = "GetProducts";
            return View(products);
        }
        [HttpPost]  
        public ActionResult Update(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Products/UpdateProduct", product);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetProducts");
        }

        [Route("Products/{Id:int}")]
        [HttpGet]
        public ActionResult Details(int Id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Products/" + Id);
            response.EnsureSuccessStatusCode();
            Models.Product products = response.Content.ReadAsAsync<Models.Product>().Result;
            ViewBag.Title = "GetProducts";
            return View(products);
        }
        [HttpGet]
        public ActionResult SaveProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Models.Product product)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Products/SaveProduct", product);
           response.EnsureSuccessStatusCode();
            return RedirectToAction("GetProducts");
        }
     [Route("Products/DeleteProduct/{Id:int}")]
      
        public ActionResult DeleteProduct(int Id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Products/DeleteProduct/" + Id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetProducts");
        }

    }
}