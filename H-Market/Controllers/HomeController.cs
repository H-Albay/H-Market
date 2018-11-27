using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_Market.Entity;

namespace H_Market.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {   
            return View(context.Products.Where(i=>i.IsHome && i.IsApproved).ToList());
        }
        public ActionResult Detials(int id)
        {
            return View(context.Products.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult List()
        {
            return View(context.Products.Where(i=>i.IsApproved).ToList());
        }

    }
}