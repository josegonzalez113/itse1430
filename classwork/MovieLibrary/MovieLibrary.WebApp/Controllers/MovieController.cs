using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieLibrary.Business;
using MovieLibrary.Business.SqlServer;

namespace MovieLibrary.WebApp.Controllers
{
    public class MovieController : Controller
    {
        public MovieController ()
        {
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _database = new SqlMovieDatabase(connString.ConnectionString);
        }
        // GET: Movie
        [HttpGet]
        public ActionResult Index()
        {
            var movies = _database.GetAll();
            //return View();
            return Json(movies, JsonRequestBehavior.AllowGet);
        }

        private readonly IMovieDatabase _database;
    }
}