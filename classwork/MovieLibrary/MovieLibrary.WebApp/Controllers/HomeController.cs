using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary.WebApp.Controllers
{
    //[Route]
    public class HomeController : Controller
    {
        //[Description]
        //[return: Description]
        //public ActionResult Index([Description] int value)
        public ActionResult Index()
        {
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