using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View();
        }

        [HttpGet]
        public ActionResult addAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");   
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}