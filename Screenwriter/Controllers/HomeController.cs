using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.Controllers
{
	public class HomeController : Controller
	{
		public HomeRepository repo = new HomeRepository();

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

		public ActionResult Search()
		{
			var model = (from sub in repo.GetAllSubtitles()
							 join lang in repo.GetAllLanguages()
							 on sub.LanguageID equals lang.ID
							 orderby sub.DownloadCount descending
							 select new
							 {
								 subtitle = sub,
								 language = lang
							 }
										).Take(10).ToList();
			return View(model);
		}
	}
}