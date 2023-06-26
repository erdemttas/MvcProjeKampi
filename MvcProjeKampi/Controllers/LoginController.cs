using DataAccessLayer.concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Admin p)
		{
			Context c = new Context();
			var adminuserinfo = c.admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
			if (adminuserinfo != null)
			{
				FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
				Session
				return RedirectToAction("Index", "AdminCategory");
			}
			else
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}