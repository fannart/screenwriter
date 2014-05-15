using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.ViewModels
{
	public class SearchFormViewModel
	{
		public string Title { get; set; }
		public DateTime PublishDate { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }
		public List<SelectListItem> Languages { get; set; }
		public string MediaGenres { get; set; }
		public List<SelectListItem> MediaTypes { get; set; }
		public string Course { get; set; }
		public string School { get; set; }
		public string Lecturer { get; set; }

		public SearchFormViewModel()
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