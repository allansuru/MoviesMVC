﻿using System;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {


            throw new Exception("Excessão forçada");

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