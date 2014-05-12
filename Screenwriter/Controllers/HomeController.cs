using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
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
        public ActionResult LoggedInHomePage()
        {
            return View();
        }
        public ActionResult ViewRequests()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult History()
        {
            return View();
        }
        public ActionResult SearchResults()
        {
            return View();
        }
        public ActionResult Request()
        {
            return View();
        }
        public ActionResult PendingRequests()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
	}
}