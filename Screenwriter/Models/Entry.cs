using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a single screenshot translation in a subtitle.</summary>
	public class Entry
	{
		public int ID { get; set; }
		public int SubtitleID { get; set; }
		/// <summary>
		/// The start time of this entries screentime.</summary>
		public DateTime StartTime { get; set; }
		/// <summary>
		/// The end time of this entries screentime.</summary>
		public DateTime Stoptime { get; set; }
		/// <summary>
		/// The first line of subtitle entry.</summary>
		public string Line1 { get; set; }
		/// <summary>
		/// The second line of subtitle entry.</summary>
		public string Line2 { get; set; }
		
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual Subtitle Subtitle { get; set; }

		public Entry()
		{

		}
		public Entry(DateTime currentTime)
		{
			StartTime = currentTime;
		}
	}
}