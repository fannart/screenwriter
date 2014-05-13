using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.ViewModels
{
	public class EditorViewModel
	{
		public struct SubtitleLanguage
		{
			public Language LanguageReferenceOption { get; set; }
			public int SubtitleID { get; set; }
		}
		public List<SubtitleLanguage> ReferenceLanguages { get; set; }

		public Subtitle ReferenceSubtitle { get; set; }
		public Subtitle WorkingSubtitle { get; set; }
		public Language WorkingLanguage { get; set; }
	}
}