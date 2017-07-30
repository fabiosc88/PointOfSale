using Newtonsoft.Json;
using PointOfSale.Application.Apps;
using PointOfSale.Application.ViewModels;
using PointOfSale.Mvc.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PointOfSale.Mvc.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProductApplication _productApplication;
        private readonly PaymentMethodApplication _paymentMethodApplication;

        public ShopController(ProductApplication productApplication, PaymentMethodApplication paymentMethodApplication)
        {
            _productApplication = productApplication;
            _paymentMethodApplication = paymentMethodApplication;
        }

        public ActionResult Index()
        {
            var vm = _productApplication.List();

            return View(vm);
        }

        public ActionResult Cart()
        {
            ViewBag.PaymentMethods = new SelectList(_paymentMethodApplication.List(), "Name", "Name");
            return View();
        }

        [AllowCrossSiteJson]
        public ActionResult LoadCartData(List<string> items)
        {
            if(items != null)
            {
                var itemsReturn = _productApplication.GetMany(items.ConvertAll(Guid.Parse));
                return Json(itemsReturn.Select(x => new { x.Id, x.Name, x.Price }), JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}