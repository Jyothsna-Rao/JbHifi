﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApiInMVC.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}