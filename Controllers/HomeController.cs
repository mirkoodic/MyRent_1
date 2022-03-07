using MyRentApp_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyRentApp_1.Controllers
{
    public class HomeController : Controller
    {
        private myRent_dbEntities db = new myRent_dbEntities();

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

        public ActionResult Apartmani(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var proizvodi = from s in db.apartmani
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                proizvodi = proizvodi.Where(s => s.naziv.Contains(searchString)
                                       || s.opis.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    proizvodi = proizvodi.OrderByDescending(s => s.naziv);
                    break;
                case "Date":
                    proizvodi = proizvodi.OrderBy(s => s.datum);
                    break;
                case "date_desc":
                    proizvodi = proizvodi.OrderByDescending(s => s.datum);
                    break;
                default:
                    proizvodi = proizvodi.OrderBy(s => s.naziv);
                    break;
            }
            return View(proizvodi.ToList());


        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proizvodi = from s in db.apartmani
                            select s;
            proizvodi = proizvodi.Where(s => s.SEO_Url.Contains(id));


            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);

        }

    }
}