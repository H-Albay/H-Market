﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H_Market.Identity;
using H_Market.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace H_Market.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken
        ]

        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.UserName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atıyabilirsiniz.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");

                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserEror","Kullanıcı oluşturma hatası.");
                }
            }
            return View(model);
        }



        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                //login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);
                if (user!=null)
                {
                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak.
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    (new AuthenticationProperties()).IsPersistent = model.RememberMe;                   
                    authManager.SignIn(authProperties, identityclaims);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("LoginUserEror","Böyle bir kullanıcı yok");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}