using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class TestController : Controller
    {
       
        public ActionResult Login(string name, string role)
        {
            //pasamos datos del controler a la view
            ViewBag.Name = name;
            ViewBag.Role = role;
            return View();
        }

        public ActionResult SearchByTitle(string title)
        {
            ViewBag.Title=title;
            return View();
        }
    }
}