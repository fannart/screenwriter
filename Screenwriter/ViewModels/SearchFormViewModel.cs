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
		public List<SelectListItem> MediaLanguages { get; set; }
		public List<SelectListItem> SubtitleLanguages { get; set; }
		public List<SelectListItem> MediaGenres { get; set; }
		public List<SelectListItem> MediaTypes { get; set; }
		public string Course { get; set; }
		public string School { get; set; }
		public string Lecturer { get; set; }
	}
}