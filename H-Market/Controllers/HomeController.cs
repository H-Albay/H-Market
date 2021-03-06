﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_Market.Entity;
using H_Market.Models;

namespace H_Market.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            var products = context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Desciption = i.Desciption.Length > 50 ? i.Desciption.Substring(0, 47) + "..." : i.Desciption,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId

            }).ToList();
            return View(products);
        }
        public ActionResult Detials(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id) //id parametrem RouteConfigdeki idden geliyor
        {
            var products = context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Desciption = i.Desciption.Length > 50 ? i.Desciption.Substring(0, 47) + "..." : i.Desciption,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image ?? "1.jpg",
                CategoryId = i.CategoryId

            }).AsQueryable();

            if (id != null) //Kategori id boş değil ise ilgili id getir.
            {
                products = products.Where(i => i.CategoryId == id);

            }
            return View(products.ToList());
        }


        public PartialViewResult GetCategories()    //parçalı view oluşturulup istenildiği taktirde kullanıklabilir.
        {
            return PartialView(context.Categories.ToList());

        }
    }
    
}