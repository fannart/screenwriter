using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a genre for a specific media.</summary>
	public class MediaGenre
	{
		public int ID { get; set; }
		public int MediaID { get; set; }
		/// <summary>
		/// A string containing exactly one genre.</summary>
		public string Genre { get; set; }
	}
}