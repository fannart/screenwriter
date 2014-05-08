using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a movie media.</summary>
	public class Movie : Media
	{
		/// <summary>
		/// The ID imdb uses to identify movies.</summary>
		public int ImdbID { get; set; }
		/// <summary>
		/// The URL to the imdb website for this movie.</summary>
		public string ImdbURL { get; set; }
	}
}