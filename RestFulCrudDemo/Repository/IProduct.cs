using RestFulCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulCrudDemo.Repository
{
    interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string id);
        Product SaveProduct(Product product);
        bool UpdateProduct(Product product);
        void Delete(int id);
    }
}
