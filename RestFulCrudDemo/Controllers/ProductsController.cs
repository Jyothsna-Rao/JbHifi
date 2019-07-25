using RestFulCrudDemo.Models;
using RestFulCrudDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFulCrudDemo.Controllers
{
   [RoutePrefix("api/Products")]
   
    public class ProductsController : ApiController
    {

        private static readonly ProductsRepository ProductRepository = new ProductsRepository();

       

        // GET: api/Products
        [Route("")]
        public IHttpActionResult GetProducts()
        {
            var product = ProductRepository.GetProducts();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [Route("{Id:int}")]
        public IHttpActionResult GetProduct(string Id)
        {

            var product = ProductRepository.GetProduct(Id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
       
      [Route("~/api/Products/GetProductsByFilter")]
        public IHttpActionResult GetProductsByFilter([FromUri]ProductFilter product )
        {
            if (product == null) throw new ArgumentNullException("product");

            ProductFilter productObj = new ProductFilter { Brand = product.Brand, Description = product.Description, Model = product.Model };

            var productFilter = ProductRepository.GetProducts(productObj);

            if (productFilter == null)
            {
                return NotFound();
            }

            return Ok(productFilter);

        }

        // POST: api/Products/
        [Route("SaveProduct")]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            var savedProduct = ProductRepository.SaveProduct(product);

            var response = Request.CreateResponse(HttpStatusCode.Created, savedProduct);

            var uri = Url.Link("DefaultApi", new { id = product.Id, controller = "Products" });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT: api/Products/2
        [Route("UpdateProduct")]
        
        public HttpResponseMessage Put([FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            ProductRepository.UpdateProduct(product);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // DELETE: api/Products/2
        [Route("DeleteProduct/{Id:int}")]
        
        public HttpResponseMessage Delete(int Id)
        {
            var product = ProductRepository.GetProduct(Id.ToString());

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ProductRepository.Delete(Id);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
