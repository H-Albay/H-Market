﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using H_Market.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace H_Market.Entity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roller
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole(){Name = "admin",Description = "admin rolü"};
                manager.Create(role);

            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole(){ Name = "user", Description = "user rolü" };
                manager.Create(role);

            }

            //admin
            if (!context.Users.Any(i => i.Name == "hakanalbay"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser(){Name = "hakan",Surname = "albay",UserName = "hakanalbay",Email = "hakanalbay2@gmail.com"};
                manager.Create(user,"admin2345");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id, "user");

            }
            //user
            if (!context.Users.Any(i => i.Name == "gurkanalbay"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "gurkan", Surname = "albay", UserName = "gurkanalbay", Email = "g@gmail.com" };
                manager.Create(user, "user12345");
                manager.AddToRole(user.Id, "user");

            }


            base.Seed(context);
        }
    }
}