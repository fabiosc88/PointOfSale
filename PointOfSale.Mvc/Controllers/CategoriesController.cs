using PointOfSale.Application.Apps;
using PointOfSale.Application.ViewModels;
using PointOfSale.Mvc.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOfSale.Mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApplication _categoryApplication;

        public CategoriesController(CategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_categoryApplication.List());
        }

        public ActionResult Create()
        {
            var vm = new CategoryViewModel();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                //Toast message
                this.AddToastMessage("", "Error while creating new Category.", ToastType.Error);
                return View("Create", vm);
            }

            var result = _categoryApplication.Create(vm);


            if (result != null)
            {
                this.AddToastMessage("", "Category created with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while creating new Category.", ToastType.Error);
                return View("Create", vm);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var vm = _categoryApplication.Get(id);

            if (vm != null)
            {
                return View("Edit", vm);
            }
            else
            {
                this.AddToastMessage("", "Category not found.", ToastType.Info);
                return RedirectToAction("Index");
            }
        }

        [HttpPut]
        public ActionResult Edit(Guid id, CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                this.AddToastMessage("", "Error while editing Category.", ToastType.Error);
                return View("Edit", vm);
            }

            var result = _categoryApplication.Update(vm, id);


            if (result)
            {
                this.AddToastMessage("", "Category edited with success.", ToastType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddToastMessage("", "Error while editing Category.", ToastType.Error);
                return View("Edit", vm);
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var result = _categoryApplication.Delete(id);

            if (result)
            {
                this.AddToastMessage("", "Category deleted with success.", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("", "Error while deleting Category.", ToastType.Error);
            }

            return RedirectToAction("Index");
        }
    }
}