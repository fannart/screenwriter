using Screenwriter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.ViewModels
{	
	public class MultiSelectList
	{
		IEnumerable Items {get; set;}
		string lang_id {get; set;}
		string lang_name {get; set;}
		IEnumerable selectedValues {get; set;}
	}

	public class SearchResult
	{
		public string Title { get; set; }
		public DateTime Published { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }
	}


	public class SearchResultsViewModel
	{
		public List<SelectListItem> LangSearch { get; set; }
		public List<SearchResult> Results { get; set; }
		public string Title { get; set; }
		public List<SelectListItem> MediaLanguage { get; set; }
		public List<SelectListItem> SearchGenre { get; set; }
		public List<SelectListItem> MediaType { get; set; }
		public int? YearPublished { get; set; }
		public int? Season { get; set; }
		public int? Episode { get; set; }
	}
}