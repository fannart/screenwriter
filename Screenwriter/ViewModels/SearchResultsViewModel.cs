using Screenwriter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
		public List<Language> LangSearch { get; set; }
		public List<SearchResult> Results { get; set; }
	}
}