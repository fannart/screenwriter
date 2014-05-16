﻿using Microsoft.AspNet.Identity;
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
		public ActionResult Index()
		{
			return RedirectToAction("Search");
		}

		public ActionResult Media(int? id)
		{
			// TODO: Create MediaViewModel for the view and recreate the view.

			// Make sure request is for a specific media.
			if (id.HasValue)
			{
				// Repository to access database.
				HomeRepository repo = new HomeRepository();
				// ID of requested media.
				int mediaID = id.Value;
				Media media = repo.GetMediaById(mediaID);

				return View(media);
			}
			// Getting this far means an unexpected error.
			return View("Error");
		}

		public ActionResult Search()
		{
			HomeRepository repo = new HomeRepository();
			SearchViewModel model = new SearchViewModel();

			model.MostDownloaded = GetTopTenMostDownloadedSubtitles();
			model.NewestSubtitles = GetTopTenNewestSubtitles();
			model.MostRequested = GetTopTenMostRequested();

			model.SearchForm = new SearchFormViewModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult Search(FormCollection searchForm)
		{
			HomeRepository repo = new HomeRepository();
			SearchViewModel model = new SearchViewModel();

			model.MostDownloaded = GetTopTenMostDownloadedSubtitles();
			model.NewestSubtitles = GetTopTenNewestSubtitles();
			model.MostRequested = GetTopTenMostRequested();

			List<Media> mediaResults = new List<Media>();
			
			// Check for search string within media titles.
			string titleSearch = searchForm["titleSearch"].ToLower();
			if (!String.IsNullOrEmpty(titleSearch))
			{
				mediaResults = repo.GetAllMedia()
					.Where(m => m.Title.ToLower().Contains(titleSearch))
					.ToList();
			}
			else { mediaResults = repo.GetAllMedia().ToList(); }

			// Convert media list to a list of SearchResults
			model.Results = new List<SearchResult>();
			foreach(var media in mediaResults)
			{
				Language language = repo.GetLanguageById(media.LanguageID);
				string mediaTypeString;
				if (media.Type == 0) { mediaTypeString = "Movie"; }
				else if (media.Type == 1) { mediaTypeString = "TVShow"; }
				else { mediaTypeString = "Lecture"; }
				model.Results.Add(new SearchResult
				{
					MediaID = media.ID,
					Title = media.Title,
					Course = media.Course,
					Season = media.Season,
					Episode = media.Episode,
					MediaType = media.Type,
					MediaTypeString = mediaTypeString,
					MediaLanguage = language,
					Published = media.publishDate
				});
			}

			return View(model);
		}

		[Authorize]
		public ActionResult CreateRequest()
		{
			return View(new Subtitle());
		}

		[Authorize]
		[HttpPost]
		public ActionResult CreateRequest(Subtitle subtitle)
		{
			HomeRepository repo = new HomeRepository();
			repo.AddSubtitle(subtitle, User.Identity.GetUserId());
			repo.Save();
			int mediaID = subtitle.MediaID;
			// TODO: Where to send the user after he/she requests a subtitle.
			return RedirectToAction("Media", new { id = mediaID });
		}

		[Authorize]
		public ActionResult UpvoteSubtitleRequest(int? id)
		{
			bool requestCreated = false;
			// ID of current logged in user.
			string userID = User.Identity.GetUserId();
			// Make sure request is for a specific subtitle.
			if (id.HasValue)
			{
				// Repository to access database.
				HomeRepository repo = new HomeRepository();
				// ID of requested subtitle.
				int subtitleID = id.Value;
				// Check if user has not requested current subtitle.
				if (!repo.RequestExists(subtitleID, userID))
				{
					// Create new request from the current user.
					repo.AddRequest(subtitleID, userID);
					repo.Save();
					requestCreated = true;
				}
				// Get number of requests for the subtitle
				int requestCount = repo.NumberOfRequests(subtitleID);
				var model = new { requestCreated = requestCreated, requestCount = requestCount };
				return Json(model, JsonRequestBehavior.AllowGet);
			}
			// Getting this far means an unexpected error.
			return View("Error");
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
		/*
        public ActionResult Request()
        {
            return View();
        }
		*/
        public ActionResult PendingRequests()
        {
            return View();
		}

		private List<TopTen> GetTopTenMostRequested()
		{
			HomeRepository repo = new HomeRepository();
			List<TopTen> topTen = new List<TopTen>();
			List<Subtitle> mostRequestedSubtitles = repo.GetAllSubtitles()
				.Where(s => !s.TranslationIsCompleted && s.Requests.Count > 0)
				.OrderByDescending(s => s.Requests.Count)
				.Take(10)
				.ToList();
			foreach (var subtitle in mostRequestedSubtitles)
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				topTen.Add(new TopTen
				{
					Subtitle = subtitle,
					Language = language,
					Media = media
				});
			}
			return topTen;
		}

		private List<TopTen> GetTopTenNewestSubtitles()
		{
			HomeRepository repo = new HomeRepository();
			List<TopTen> topTen = new List<TopTen>();
			List<Subtitle> newestSubtitles = repo.GetAllSubtitles()
				.Where(s => s.TranslationIsCompleted)
				.OrderByDescending(s => s.DateCompleted)
				.Take(10)
				.ToList();
			foreach (var subtitle in newestSubtitles)
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				topTen.Add(new TopTen
				{
					Subtitle = subtitle,
					Language = language,
					Media = media
				});
			}
			return topTen;
		}

		private List<TopTen> GetTopTenMostDownloadedSubtitles()
		{
			HomeRepository repo = new HomeRepository();
			List<TopTen> topTen = new List<TopTen>();
			List<Subtitle> mostDownloadedSubtitles = repo.GetAllSubtitles()
				   .Where(s => s.TranslationIsCompleted)
				   .OrderByDescending(s => s.DownloadCount)
				   .Take(10)
				   .ToList();
			foreach (var subtitle in mostDownloadedSubtitles)
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				topTen.Add(new TopTen
				{
					Subtitle = subtitle,
					Language = language,
					Media = media
				});
			}
			return topTen;
		}

		private List<SearchResult> NewSearch()
		{
			HomeRepository repo = new HomeRepository();
			List<SearchResult> NewSearch = new List<SearchResult>();
			NewSearch = (from m in repo.GetAllMedia().ToList()
						 join l in repo.GetAllLanguages().ToList()
						 on m.LanguageID equals l.ID
						 orderby m.Title ascending
						 select new SearchResult
						 {
							 Title = m.Title,
							 Course = m.Course,
							 Episode = m.Episode,
							 Season = m.Season,
							 MediaLanguage = l,
							 MediaID = m.ID,
							 Published = m.publishDate,
							 MediaType = m.Type
						 }).ToList();
			return NewSearch;
		}

		private List<SearchResult> SearchByTitle(List<SearchResult> Results, string title) 
		{
			HomeRepository repo = new HomeRepository();
			Results = (from m in repo.GetAllMedia().ToList()
					   join sub in repo.GetAllSubtitles().ToList()
					   on m.ID equals sub.MediaID
					   join lang in repo.GetAllLanguages().ToList()
					   on sub.LanguageID equals lang.ID
					   where m.Title.ToLower().Contains(title.ToLower())
					   orderby m.Title ascending
					   select new SearchResult
					   {
						   Title = m.Title,
						   Published = m.publishDate
					   }).ToList();
			return Results;
		}
		private List<SearchResult> SearchByLanguage(List<SearchResult> Results, List<SelectListItem> languages)
		{
			HomeRepository repo = new HomeRepository();
			List<SearchResult> LangResult = new List<SearchResult>();
			List<SearchResult> Temp = new List<SearchResult>();
			foreach (var l in languages)
			{
				if (l.Selected == true)
				{
					Temp = (from r in Results.ToList()
							join sub in repo.GetAllSubtitles().ToList()
							on r.MediaID equals sub.MediaID
							join la in repo.GetAllLanguages().ToList()
							on l.Text equals la.Name
							orderby r.Title ascending
							select new SearchResult
							{
								Title = r.Title
							}).ToList();
				}
				foreach (var r in Temp)
				{
					LangResult.Add(r);
				}
			}
			return LangResult;
		}
	}
}