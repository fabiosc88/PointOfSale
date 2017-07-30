using PointOfSale.Application.Apps;
using PointOfSale.Application.ViewModels;
using PointOfSale.Mvc.Notifications;
using System;
using System.Web.Mvc;

namespace PointOfSale.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApplication _productApplication;
        private readonly CategoryApplication _categoryApplication;

        public ProductsController(ProductApplication productApplication, CategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }

        public ActionResult Index()
        {
            return View(_productApplication.List());
        }

        public ActionResult Create()
        {
            var vm = new ProductViewModel();
            ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name"); 

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Error while creating new Product.", ToastType.Error);
                ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name");
                return View("Create", vm);
            }

            var result = _productApplication.Create(vm);


            if (result != null)
            {
                this.AddToastMessage("", "Product created with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while creating new Product.", ToastType.Error);
                ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name");
                return View("Create", vm);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var vm = _productApplication.Get(id);

            if (vm != null)
            {
                ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name");
                return View("Edit", vm);
            }
            else
            {
                this.AddToastMessage("", "Product not found.", ToastType.Info);
                return RedirectToAction("Index");
            }
        }

        [HttpPut]
        public ActionResult Edit(Guid id, ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Error while editing Product.", ToastType.Error);
                ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name");
                return View("Edit", vm);
            }

            var result = _productApplication.Update(vm, id);


            if (result)
            {
                this.AddToastMessage("", "Product edited with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while editing Product.", ToastType.Error);
                ViewBag.Categories = new SelectList(_categoryApplication.List(), "Id", "Name");
                return View("Edit", vm);
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var result = _productApplication.Delete(id);

            if (result)
            {
                this.AddToastMessage("", "Product deleted with success.", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Error while deleting Product.", ToastType.Error);
            }

            return RedirectToAction("Index");
        }
    }
}