using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.ViewModels
{
	public class SelectLanguage
	{
		public Language ReferenceLanguage { get; set; }
		public int SubtitleID { get; set; }
	}

	public class EditorViewModel
	{
		/// <summary>
		/// The subtitle to be edited.</summary>
		public Subtitle WorkingSubtitle { get; set; }
		/// <summary>
		/// The media to be translated.</summary>
		public Media Media { get; set; }
		/// <summary>
		/// A list of subtitles available for reference.</summary>
		public List<SelectListItem> LanguageDropDownList { get; set; }

		public List<SelectLanguage> ReferenceLanguages { get; set; }

		public Subtitle ReferenceSubtitle { get; set; }
		public Language WorkingLanguage { get; set; }
	}
}