﻿using Screenwriter.Models;
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
			HomeRepository repo = new HomeRepository();

			SearchViewModel model = new SearchViewModel();
			foreach(var subtitle in repo.GetAllSubtitles().ToList())
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				model.MostDownloaded.Add(new TopTen
				{
					Subtitle = subtitle, 
					Language = language,
					Media = media
				});
			}

			return View(model);
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
	}
}