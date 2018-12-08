using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_Market.Entity;
using H_Market.Models;

namespace H_Market.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        
        //[Authorize] Yaparsam kullanıcı giriş yaptıysa görebilir.
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart=GetCart();
            if (cart.CartLines.Count==0)
            {
               ModelState.AddModelError("UrunYokError","Sepetinizde ürün bulunamamaktadır."); 
            }

            if (ModelState.IsValid)
            {
                //Siparişi veritabanına kaydet
                SaveOrder(cart, entity);
                //cartı sıfırla
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }

            
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order=new Order();
            order.OrderNumber="H"+new Random().Next(1,99999).ToString();
            order.OrderDate = DateTime.Now;

            order.AdSoyad = entity.AdSoyad;
            order.AdresBaslıgı = entity.AdresBaslıgı;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var orderline=new  OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}