using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.ViewModels
{
	public class SubtitleResult
	{
		public Subtitle Subtitle { get; set; }
		public Language Language { get; set; }
	}
	public class MediaViewModel
	{
		public Media Media { get; set; }
		public Language MediaLanguage { get; set; }
		public List<SubtitleResult> FinishedSubtitles { get; set; }
		public List<SubtitleResult> UnfinishedSubtitles { get; set; }
		public List<SelectListItem> Languages { get; set; }
		public List<SelectListItem> MediaTypes { get; set; }
		
		public MediaViewModel()
		{
			HomeRepository repo = new HomeRepository();
			var languages = repo.GetAllLanguages();

			Languages = new List<SelectListItem>();
			foreach (var lang in languages)
			{
				Languages.Add(new SelectListItem { Text = lang.Name, Value = lang.ID.ToString() });
			}

			MediaTypes = new List<SelectListItem>();
			MediaTypes.Add(new SelectListItem { Value = "0", Text = "Movie" });
			MediaTypes.Add(new SelectListItem { Value = "1", Text = "TVShow" });
			MediaTypes.Add(new SelectListItem { Value = "2", Text = "Lecture" });
		}
	}
}