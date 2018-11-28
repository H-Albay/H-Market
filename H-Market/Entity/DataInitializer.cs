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
                new Product(){Name="SONY A6 16-50MM DiJiTAL FOTOĞRAF MAKiNESi SONY A6 16-50MM DiJiTAL FOTOĞRAF MAKiNESiSONY A6 16-50MM DiJiTAL FOTOĞRAF MAKiNESi",Desciption="24.3MP APS-C Exmor APS HD CMOS Sensör 24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör24.3MP APS-C Exmor APS HD CMOS Sensör ",Price=450,Stock=9,IsApproved= true,CategoryId=1,IsHome=true,Image="4.jpg"},
                new Product(){Name="Apple Macbook Pro Touch Bar Intel Core i7 8750H 16GB 512GB SSD Radeon Pro 560X MacOs 15QHD Taşınabilir Bilgisayar MR972TU/A - Gümüş",Desciption="10/100 Ethernet	Yok Bellek Hızı 2400 MHz Bellek Yuvası   2 Bluetooth Özelliği  Var ",Price=19.999,Stock=500,IsApproved= true,CategoryId=2,Image="2.jpg"},
                new Product(){Name="LG 50UK6470 50 127 Ekran Uydu Alıcılı 4K Ultra HD Smart LED TV",Desciption= "40 inç ve üstü televizyonlarda, yetkili servis tarafından kurulum yapılması gerekmektedir.",Price=3.899,Stock=99,IsApproved= false,CategoryId=2,IsHome=true,Image="3.jpg"},
                new Product(){Name="Apple MacBook Pro Touch Bar Intel Core i7 16GB 512GB SSD Radeon Pro 555 MacOS Sierra 15.4 FHD Taşınabilir Bilgisayar MPTT2TU A - Space Grey",Desciption="Touch Bar ve Touch ID Desteği İle Yeni Nesil Kullanım",Price=18.999,Stock=23,IsApproved= true,CategoryId=3,IsHome=true,Image="5.jpg"},
                new Product(){Name="Apple iPhone 8 64 GB",Desciption="Apple yetkili servislerinden garanti kapsamı dahilinde ücretsiz faydalanabilirsiniz",Price=4.518,Stock=55,IsApproved= true,CategoryId=4,IsHome=true,Image="1.jpg"},
                new Product(){Name="Apple iPhone 6 32 GB",Desciption="Apple yetkili servislerinden garanti kapsamı dahilinde ücretsiz faydalanabilirsiniz",Price=2.750,Stock=41,IsApproved= true,CategoryId=5,IsHome=false,Image="1.jpg"},
                new Product(){Name="SONY A5 16-40MM DiJiTAL FOTOĞRAF MAKiNESi",Desciption="23MP APS-C Exmor APS HD CMOS Sensör",Price=450,Stock=34,IsApproved= true,CategoryId=2,IsHome=true,Image="4.jpg"},
                new Product(){Name="SanDisk SSD Plus 240GB 530MB-440MB/s Sata 3 2. SSD SDSSDA-240G-G26",Desciption="SanDisk SSD Plus 240GB 530MB-440MB/s Sata 3 2.5 SSD SDSSDA-240G-G26",Price=318,Stock=34,IsApproved= true,CategoryId=2,IsHome=true,Image="6.jpg"}

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