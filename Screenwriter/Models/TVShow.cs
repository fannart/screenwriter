using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a TV Show. A part of the Media classes.</summary>
	public class TVShow : Media
	{
		/// <summary>
		/// The ID imdb uses to identify the particular episode.</summary>
		public string ImdbID { get; set; }
		/// <summary>
		/// The URL to the imdb website for this particular episode.</summary>
		public string ImdbURL { get; set; }
		/// <summary>
		/// The season number of the episode.</summary>
		public int Season { get; set; }
		/// <summary>
		/// The episode number of the episode.</summary>
		public int Episode { get; set; }
	}
}