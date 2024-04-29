﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCapp1.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities1 db; 

     
        public CodeController()
        {
            db = new NorthwindEntities1();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GermanyCustomers()
        {
            var germanyCustomers = db.Customers.Where(c => c.Country == "Germany").ToList();
            ViewBag.GermanyCustomers = germanyCustomers;
            return View();
        }

        public ActionResult CustomerWithOrder10248()
        {
            var customer = db.Customers.FirstOrDefault(c => c.Orders.Any(o => o.OrderID == 10248));
            ViewBag.Customer = customer;
            return View();
        }
    }
}