﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cranberrries.Web.Models;
using Microsoft.AspNet.Identity;

namespace Cranberrries.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //Roles.AddUserToRole(User.Identity.Name,RoleName.CanBeSongWriter);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}