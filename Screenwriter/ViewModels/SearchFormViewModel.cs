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
		public int Type { get; set; }
		public List<int> MediaLanguages { get; set; }
		public List<int> SubtitleLanguages { get; set; }
		public List<int> MediaGenres { get; set; }
		public string Course { get; set; }
		public string School { get; set; }
		public string Lecturer { get; set; }
	}
}