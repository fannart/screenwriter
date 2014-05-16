using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.ViewModels
{
	public class SubtitleResult
	{
		public Subtitle Subtitle { get; set; }
		public Language Language { get; set; }
	}
	public class MediaViewModel
	{
		public Media Media { get; set; }
		public Language MediaLanguage { get; set; }
		public List<SubtitleResult> FinishedSubtitles { get; set; }
		public List<SubtitleResult> UnfinishedSubtitles { get; set; }
	}
}