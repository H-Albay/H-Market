using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace H_Market.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün İsmi")]
        public string Name { get; set; }
        [DisplayName("Ürün  Açıklama")]
        public string Desciption { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        [DisplayName("Ürün  Fotoğraf")]
        public string Image { get; set; }
        [DisplayName("Onay")]
        public bool IsApproved { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }

        public  int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}