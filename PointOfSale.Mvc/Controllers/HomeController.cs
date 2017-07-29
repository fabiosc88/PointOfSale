using PointOfSale.Application;
using PointOfSale.Application.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOfSale.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryApplication _product;

        public HomeController(CategoryApplication product)
        {
            _product = product;
        }

        public ActionResult Index()
        {
            var a = _product.List();
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