using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace H_Market.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //List<Category> k = new List<Category>() yada
            var categories = new List<Category>()
            {
                new Category(){ Name="Kamera",Description="Kamera Ürünleri"},
                new Category(){ Name="Bilgisayar",Description="Bilgisayar Ürünleri"},
                new Category(){ Name="Elektronik",Description="Elektronik Ürünleri"},
                new Category(){ Name="Telefon",Description="Telefon Ürünleri"},
                new Category(){ Name="Beyaz Eşya",Description="Beyaz Eşya Ürünleri"},

            };

            foreach (var i in categories)
            {
                context.Categories.Add(i);
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product(){Name="SONY A6000 16-50MM DiJiTAL FOTOĞRAF MAKiNESi",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=250,Stock=9,IsApproved= true,CategoryId=1,IsHome=true},
                new Product(){Name="MAKiNESi",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=350,Stock=500,IsApproved= true,CategoryId=1},
                new Product(){Name="A6000",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=450,Stock=99,IsApproved= false,CategoryId=2,IsHome=true},
                new Product(){Name="16-50MM",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=550,Stock=23,IsApproved= true,CategoryId=3},
                new Product(){Name="DiJiTAL",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=650,Stock=55,IsApproved= false,CategoryId=4,IsHome=true},
                new Product(){Name="FOTOĞRAF",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=750,Stock=41,IsApproved= false,CategoryId=5},
                new Product(){Name="MAKiNESi",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör",Price=850,Stock=34,IsApproved= true,CategoryId=2,IsHome=true},

            };

            foreach (var i in products)
            {
                context.Products.Add(i);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}