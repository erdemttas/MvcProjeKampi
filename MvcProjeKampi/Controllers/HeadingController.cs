﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
	public class HeadingController : Controller
	{
		HeadingManager hm = new HeadingManager(new EfHeadingDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
		WriterManager wm = new WriterManager(new EfWriterDal());
		public ActionResult Index()
		{
			var headinsvalue = hm.GetList();
			return View(headinsvalue);
		}

		[HttpGet]
		public ActionResult AddHeading()
		{
			List<SelectListItem> valuecategory = (from x in cm.GettList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
			List<SelectListItem> valuewriter = (from x in wm.GetList() select new SelectListItem { Text = x.WriterName, Value = x.WriterID.ToString() }).ToList().ToList();
			ViewBag.vlc = valuecategory;
			ViewBag.vlw = valuewriter;
			return View();
		}

		[HttpPost]
		public ActionResult AddHeading(Heading p)
		{
			p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			hm.HeadingAdd(p);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EditHeading(int id)
		{
			List<SelectListItem> valuecategory = (from x in cm.GettList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
			ViewBag.vlc = valuecategory;
			var HeadingValue = hm.GetByID(id);
			return View(HeadingValue);
		}

		public ActionResult DeleteHeading(int id)
		{
			var headingvalues=hm.GetByID(id);
			headingvalues.HeadingStatus = false;
			hm.HeadingDelete(headingvalues);
			return RedirectToAction("Index");
		}
	}
}