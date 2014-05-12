using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a media which will have existing subtitles,
	/// requested subtitles, or both.</summary>
	public abstract class Media
	{
		public int ID { get; set; }
		public int LanguageID { get; set; }
		public string Title { get; set; }
		/// <summary>
		/// The lengt of the media represented in minutes.</summary>
		public int length { get; set; }
		/// <summary>
		/// Contains the youtube identifying string needed to embed the video.</summary>
		public string YoutubeIdentifier { get; set; }
		/// <summary>
		/// Contains the vimeo identifying string needed to embed the video.</summary>
		public string VimeoIdentifier { get; set; }
		/// <summary>
		/// The date of original publication of the media.</summary>
		public DateTime publishDate { get; set; }

		public virtual ICollection<MediaGenre> MediaGenres { get; set; }
		public virtual ICollection<Subtitle> Subtitles { get; set; }
	}
}