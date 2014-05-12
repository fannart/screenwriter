using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	public class TVShow : Media
	{
		/// <summary>
		/// The ID imdb uses to identify the particular episode.</summary>
		public string ImdbID { get; set; }
		/// <summary>
		/// The URL to the imdb website for this particular episode.</summary>
		public string ImdbURL { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }
	}
}