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
										Media = m,
									}).Take(10).ToList();
			model.NewestSubtitles = (from sub in repo.GetAllSubtitles().ToList()
									 where sub.TranslationIsCompleted == true
									 join lang in repo.GetAllLanguages().ToList()
									 on sub.LanguageID equals lang.ID
									 join m in repo.GetAllMedia().ToList()
									 on sub.MediaID equals m.ID
									 orderby sub.DateAdded descending
									 select new TopTen
									 {
										 Subtitle = sub,
										 Language = lang,
										 Media = m,
									 }).Take(10).ToList();

			model.MostRequested = (from sub in repo.GetAllSubtitles().ToList()
								   where sub.TranslationIsCompleted == false
								   join lang in repo.GetAllLanguages().ToList()
								   on sub.LanguageID equals lang.ID
								   join m in repo.GetAllMedia().ToList()
								   on sub.MediaID equals m.ID
								   orderby repo.NumberOfRequests(sub.ID) descending
								   select new TopTen
								   {
									   Subtitle = sub,
									   Language = lang,
									   Media = m,
								   }).Take(10).ToList();



			return View(model);

		}

		public ActionResult SearchResults(string titleSearch)
		{
			SearchResultsViewModel result = new SearchResultsViewModel();

			result.LangSearch = repo.GetAllLanguages().ToList();

			result.SearchInstance.MediaLanguage = repo.GetAllLanguages().ToList();

			result.SearchInstance.MediaType = repo.GetAllMedia().ToList();

			result.SearchInstance.SearchGenre = new List<MediaGenre>();


			if (!String.IsNullOrEmpty(titleSearch))
			{
				result.Results = (from m in repo.GetAllMedia().ToList()
								  join sub in repo.GetAllSubtitles().ToList()
								  on m.ID equals sub.MediaID
								  join lang in repo.GetAllLanguages().ToList()
								  on sub.LanguageID equals lang.ID
								  where m.Title.Contains(titleSearch)
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

	}
}