using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
		CategoryManager cm = new CategoryManager(new EfCategoryDal());

		// GET: Category
		public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GettList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory() { 
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
           // cm.CategoryAddBL(p);
            CategoryValidator categoryValidator= new CategoryValidator();
            FluentValidation.Results.ValidationResult results =categoryValidator.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
    }
}