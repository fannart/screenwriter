using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a media which will have existing subtitles,
	/// requested subtitles, or both.</summary>
	public class Media
	{
		public int ID { get; set; }
		[Required]
		public int LanguageID { get; set; }
		[Required]
		public string Title { get; set; }
		/// <summary>
		/// MediaType: Movie = 0, TVShow = 1, Lecture = 2.</summary>
		[Required]
		public int Type { get; set; }
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
		/// <summary>
		/// The course in which the lecture was given.</summary>
		public string Course { get; set; }
		/// <summary>
		/// The school in which the lecture was given.</summary>
		public string School { get; set; }
		/// <summary>
		/// The lecturer who gave the lecture.</summary>
		public string Lecturer { get; set; }

		public virtual ICollection<MediaGenre> MediaGenres { get; set; }
		public virtual ICollection<Subtitle> Subtitles { get; set; }
	}
}