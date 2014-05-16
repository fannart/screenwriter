using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a single language translation for a particular media.</summary>
	public class Subtitle
	{
		public int ID { get; set; }
		public int MediaID { get; set; }
		public int LanguageID { get; set; }

		/// <summary>
		/// Indicates if the translation of this subtitle has been completed 
		/// and the subtitle is therefore ready to be downloaded.</summary>
		public bool TranslationIsCompleted { get; set; }
		/// <summary>
		/// The amount of times this subtitle has been downloaded.</summary>
		public int DownloadCount { get; set; }
		/// <summary>
		/// The timestamp when this translation was first requested.</summary>
		public DateTime DateAdded { get; set; }
		/// <summary>
		/// The date when the subtitle translation was last updated.</summary>
		public DateTime LastUpdated { get; set; }
		/// <summary>
		/// The timestamp when this translation was completed 
		/// and became available for download.</summary>
		public DateTime? DateCompleted { get; set; }

		public virtual ICollection<Entry> Entries { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Request> Requests { get; set; }

		public Subtitle()
		{
			DateAdded = DateTime.Now;
			LastUpdated = DateTime.Now;
			DateCompleted = null;
			TranslationIsCompleted = false;
			DownloadCount = 0;
		}
	}
}