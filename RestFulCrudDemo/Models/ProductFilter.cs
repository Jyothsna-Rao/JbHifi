using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFulCrudDemo.Models
{
    public class ProductFilter
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}