using PointOfSale.Application.Apps;
using PointOfSale.Application.ViewModels;
using PointOfSale.Mvc.Notifications;
using System;
using System.Web.Mvc;

namespace PointOfSale.Mvc.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly PaymentMethodApplication _paymentMethodApplication;

        public PaymentMethodsController(PaymentMethodApplication paymentMethodApplication)
        {
            _paymentMethodApplication = paymentMethodApplication;
        }

        public ActionResult Index()
        {
            return View(_paymentMethodApplication.List());
        }

        public ActionResult Create()
        {
            var vm = new PaymentMethodViewModel();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(PaymentMethodViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //Toast message
                this.AddToastMessage("", "Error while creating new Payment Method.", ToastType.Error);
                return View("Create", vm);
            }

            var result = _paymentMethodApplication.Create(vm);


            if (result != null)
            {
                this.AddToastMessage("", "Payment Method created with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while creating new Payment Method.", ToastType.Error);
                return View("Create", vm);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var vm = _paymentMethodApplication.Get(id);

            if (vm != null)
            {
                return View("Edit", vm);
            }
            else
            {
                this.AddToastMessage("", "Payment Method not found.", ToastType.Info);
                return RedirectToAction("Index");
            }
        }

        [HttpPut]
        public ActionResult Edit(Guid id, PaymentMethodViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Error while editing Payment Method.", ToastType.Error);
                return View("Edit", vm);
            }

            var result = _paymentMethodApplication.Update(vm, id);


            if (result)
            {
                this.AddToastMessage("", "Payment Method edited with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while editing Payment Method.", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var result = _paymentMethodApplication.Delete(id);

            if (result)
            {
                this.AddToastMessage("", "Payment Method deleted with success.", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Error while deleting Payment Method.", ToastType.Error);
            }

            return RedirectToAction("Index");
        }
    }
}