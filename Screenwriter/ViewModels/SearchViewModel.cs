﻿using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.ViewModels
{
	public class TopTen
	{
		public Language Language { get; set; }
		public Subtitle Subtitle { get; set; }
		public Media Media { get; set; }
	}
	
	public class SearchViewModel
	{
		public List<TopTen> MostDownloaded { get; set; }
		public List<TopTen> NewestSubtitles { get; set; }
		public List<TopTen> MostRequested { get; set; }

		public SearchViewModel()
		{
			MostDownloaded = new List<TopTen>();
			NewestSubtitles = new List<TopTen>();
			MostRequested = new List<TopTen>();
		}
	}
}