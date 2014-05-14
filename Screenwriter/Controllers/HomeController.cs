using Microsoft.AspNet.Identity;
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
			return View();
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

			List<Subtitle> mostDownloadedSubtitles = repo.GetAllSubtitles()
				.Where(s => s.TranslationIsCompleted)
				.OrderByDescending(s => s.DownloadCount)
				.Take(10)
				.ToList();
			foreach(var subtitle in mostDownloadedSubtitles)
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

			List<Subtitle> newestSubtitles = repo.GetAllSubtitles()
				.Where(s => s.TranslationIsCompleted)
				.OrderByDescending(s => s.DateCompleted)
				.Take(10)
				.ToList();
			foreach(var subtitle in newestSubtitles)
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				model.NewestSubtitles.Add(new TopTen
				{
					Subtitle = subtitle, 
					Language = language,
					Media = media
				});
			}

			List<Subtitle> mostRequestedSubtitles = repo.GetAllSubtitles()
				.Where(s => !s.TranslationIsCompleted && s.Requests.Count > 0)
				.OrderByDescending(s => s.Requests.Count)
				.Take(10)
				.ToList();
			foreach(var subtitle in mostRequestedSubtitles)
			{
				var language = repo.GetAllLanguages()
					.Where(l => l.ID == subtitle.LanguageID)
					.FirstOrDefault();
				var media = repo.GetAllMedia()
					.Where(m => m.ID == subtitle.MediaID)
					.FirstOrDefault();
				model.MostRequested.Add(new TopTen
				{
					Subtitle = subtitle, 
					Language = language,
					Media = media
				});
			}

			model.SearchForm = new SearchFormViewModel();
			return View(model);
		}
/*-----------------SEARCH RESULTS--------------------------------------------------*/
		[HttpPost]
		public ActionResult SearchResults(FormCollection searchForm)
		{
			SearchResultsViewModel result = new SearchResultsViewModel();
			HomeRepository repo = new HomeRepository();

			if (!String.IsNullOrEmpty(searchForm["titleSearch"]))
			{
				result.Results = (from m in repo.GetAllMedia().ToList()
								  join sub in repo.GetAllSubtitles().ToList()
								  on m.ID equals sub.MediaID
								  join lang in repo.GetAllLanguages().ToList()
								  on sub.LanguageID equals lang.ID
								  where m.Title.Contains(searchForm["titleSearch"])
								  orderby m.Title ascending
								  select new SearchResult
								  {
									  Title = m.Title,
									  Published = m.publishDate
								  }).ToList();

			}
			else result.Results = (from sub in repo.GetAllSubtitles().ToList()
								   where sub.TranslationIsCompleted == false
								   join lang in repo.GetAllLanguages().ToList()
								   on sub.LanguageID equals lang.ID
								   join m in repo.GetAllMedia().ToList()
								   on sub.MediaID equals m.ID
								   orderby repo.NumberOfRequests(sub.ID) descending
								   select new SearchResult
								   {
									   Title = m.Title,
									   Published = m.publishDate
								   }).ToList();

			return View(result);
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
	}
}