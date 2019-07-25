using RestFulCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFulCrudDemo.Repository
{
    public class ProductsRepository : IProduct
    {
        public static List<Product> Products { get; private set; }
        private int _nextId = 5;

        public ProductsRepository()
        {
            if (Products == null || Products.Count == 0)
            {
                Seed();
            }
        }

        private void Seed()
        {
            Products = new List<Product>();

            Products.Add(new Product()
            {
                Id = "1",
                Description = "This is Samsung S6 edge smartphone.",
                Model = "Samsung S6 edge",
                Brand = "Samsung",

            });

            Products.Add(new Product()
            {
                Id = "2",
                Description = "This is Apple Iphone",
                Model = "Apple Iphone 8",
                Brand = "Apple",
            });

            Products.Add(new Product()
            {
                Id = "3",
                Description = "This is Sony Phone ",
                Model = "Sony Erricson",
                Brand = "Sony",

            });

            Products.Add(new Product()
            {

                Id = "4",
                Description = "This is Apple IPad Pro, a revolutionary Product",
                Model = "Apple Ipad Pro",
                Brand = "Apple",
            });
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter productFilter)
        {
            return Products.Where(p => p.Brand.Equals(productFilter.Brand) || p.Description.Equals(productFilter.Description) || p.Model.Equals(productFilter.Model)).ToList();
        }

        public Product GetProduct(string id)
        {
            return Products.FirstOrDefault((p) => p.Id.Equals(id.ToString()));


            
        }

        public Product SaveProduct(Product product)
        {
            product.Id = _nextId.ToString();
            _nextId++;

            Products.Add(product);

            return product;
        }

        public bool UpdateProduct( Product product)
        {
            var index = Products.FindIndex(p => p.Id.Equals(product.Id));

            if (index == -1 && !product.Id.Equals(product.Id))
            {
                return false;
            }
            else
            {
                Products[index] = product;
            }

            return true;
        }

        public void Delete(int id)
        {
            Products.RemoveAll(p => p.Id.Equals(id.ToString()));
        }

    }
}
