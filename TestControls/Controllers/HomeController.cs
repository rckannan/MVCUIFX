﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestControls.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var onj = new List<tmp>
            {
                new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                  new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                  new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                  new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                  new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
                   new tmp() { id = 1, NAME = "kk" },
                 new tmp() { id = 3, NAME = "kk3" },
                  new tmp() { id = 4, NAME = "kk2" }, new tmp() { id = 5, NAME = "kk54" }, new tmp() { id = 2, NAME = "kk22" },
            };
            return View(onj);
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

    public class tmp
    {
        public int id { get; set; }
        public string NAME { get; set; }
    }
}