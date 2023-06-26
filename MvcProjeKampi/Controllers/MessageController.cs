using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
	public class MessageController : Controller
	{
		MessageManager mm = new MessageManager(new EfMessageDal());
		MessageValidator messsagevalidator=new MessageValidator();
		public ActionResult Inbox()
		{
			var messagelsit = mm.GetListInbox();
			return View(messagelsit);
		}

		public ActionResult Sendbox()
		{
			var messagelist = mm.GetListSendbox();
			return View(messagelist);
		}

		public ActionResult GetInBoxMessageDetails(int id)
		{
			var values=mm.GetByID(id);
			return View(values);
		}

		public ActionResult GetSendBoxMessageDetails(int id)
		{
			var values = mm.GetByID(id);
			return View(values);
		}

		[HttpGet]
		public ActionResult NewMessage()
		{
			return View();
		}

		[HttpPost]
		public ActionResult NewMessage(Message p)
		{
			ValidationResult results = messsagevalidator.Validate(p);
			if(results.IsValid)
			{
				p.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
				mm.messageAdd(p);
				return RedirectToAction("Sendbox");
			}
			else
			{
				foreach(var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();	
		}
	}
}