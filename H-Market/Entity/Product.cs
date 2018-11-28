using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H_Market.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Desciption { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public  int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}