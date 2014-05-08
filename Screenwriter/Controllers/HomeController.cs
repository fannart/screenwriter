using Screenwriter.Models;
using Screenwriter.ViewModels;
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
			SearchViewModel model = new SearchViewModel();
			model.MostDownloaded = (from sub in repo.GetAllSubtitles().ToList()
									where sub.TranslationIsCompleted == true
										   join lang in repo.GetAllLanguages().ToList()
										   on sub.LanguageID equals lang.ID
											join m in repo.GetAllMedia().ToList()
											on sub.MediaID equals m.ID
										   orderby sub.DownloadCount descending
										   select new TopTen
										   {
											   Subtitle = sub,
											   Language = lang,
											   Media = m
										   }).Take(10).ToList();
			model.NewestSubtitles = (from sub in repo.GetAllSubtitles().ToList()
									 where sub.TranslationIsCompleted == true
									join lang in repo.GetAllLanguages().ToList()
									on sub.LanguageID equals lang.ID
									join m in repo.GetAllMedia().ToList()
									on sub.MediaId equals m.ID
									orderby sub.DateAdded descending)

			model.MostRequested = (from sub in repo.GetAllSubtitles().ToList()
								   join lang in repo.GetAllLanguages().ToList()
								   on sub.LanguageID equals lang.ID
								   join m in repo.GetAllMedia().ToList()
								   on sub.MediaID equals m.ID
								   orderby repo.

			
			

			
			return View(model);
		}
	}
}