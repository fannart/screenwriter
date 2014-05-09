using Screenwriter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	public class HomeRepository
	{
		private static HomeRepository instance;

		public static HomeRepository Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new HomeRepository();
				}
				return instance;
			}
		}

		private HomeContext db = new HomeContext();
		private List<ApplicationUser> users = null;
		private List<Language> languages = null;
		private List<Subtitle> subtitles = null;
		private List<Request> requests = null;
		private List<Comment> comments = null;
		private List<Entry> entries = null;
		private List<Media> media = null;

		public HomeRepository()
		{
			InitializeMockData();
		}

		public int NumberOfRequests(int subtitleId)
		{
			int result = (from req in requests
						  where req.SubtitleID == subtitleId
						  select req).Count();
			return 0;
		}

		public IQueryable<Subtitle> GetAllSubtitles()
		{
			var result = (from sub in db.Subtitles
						  select sub).AsQueryable();
			return result;
		}
		public IQueryable<Subtitle> GetSubtitlesByLanguageId(int id)
		{
			var result = (from sub in subtitles
						  where sub.LanguageID == id
						  select sub).AsQueryable();
			return result;
		}
		public Subtitle GetSubtitleById(int id)
		{
			var result = (from sub in subtitles
						  where sub.ID == id
						  select sub).FirstOrDefault();
			return result;
		}
		public IQueryable<Language> GetAllLanguages()
		{
			var result = (from lang in languages
						  select lang).AsQueryable();
			return result;
		}
		public IQueryable<Entry> GetAllEntiesBySubtitleId(int id)
		{
			var result = (from entry in entries
						  where entry.SubtitleID == id
						  select entry).AsQueryable();
			return result;
		}
		public IQueryable<Media> GetAllMedia()
		{
			var result = (from m in media
						  select m).AsQueryable();
			return result;
		}
		public void Save()
		{
			db.SaveChanges();
		}

		private void InitializeMockData()
		{
			this.languages = new List<Language>();
			this.languages.Add(new Language { ID = 1, Name = "English" });
			this.languages.Add(new Language { ID = 2, Name = "Icelandic" });
			this.languages.Add(new Language { ID = 3, Name = "Japanese" });

			this.media = new List<Media>();
			this.media.Add(new Movie { ID = 1, Title = "12 Years a Slave" });
			this.media.Add(new Movie { ID = 2, Title = "Argo" });
			this.media.Add(new Movie { ID = 3, Title = "The Artist" });

			this.subtitles = new List<Subtitle>();
			this.subtitles.Add(new Subtitle { ID = 1, MediaID = 1, LanguageID = 2, TranslationIsCompleted = true, DownloadCount = 19, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 2, MediaID = 3, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 3, MediaID = 1, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 4, MediaID = 2, LanguageID = 1, TranslationIsCompleted = true, DownloadCount = 11, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 5, MediaID = 1, LanguageID = 1, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 6, MediaID = 3, LanguageID = 1, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 7, MediaID = 3, LanguageID = 2, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 8, MediaID = 2, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });
			this.subtitles.Add(new Subtitle { ID = 9, MediaID = 2, LanguageID = 2, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now });

			this.entries = new List<Entry>();
			this.entries.Add(new Entry { ID = 1, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 2, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 3, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 4, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 5, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 6, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 7, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 8, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });
			this.entries.Add(new Entry { ID = 9, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now });

			this.users = new List<ApplicationUser>();
			this.users.Add(new ApplicationUser { UserName = "Admin" });
			ApplicationUser fannar =new ApplicationUser { UserName = "Fannar" };
			this.users.Add(fannar);

			this.requests = new List<Request>();
			this.requests.Add(new Request { ID = 1, SubtitleID = 2, ApplicationUserID = 1 });
			this.requests.Add(new Request { ID = 2, SubtitleID = 1, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 3, SubtitleID = 3, ApplicationUserID = 1 });
			this.requests.Add(new Request { ID = 4, SubtitleID = 2, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 5, SubtitleID = 3, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 6, SubtitleID = 4, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 7, SubtitleID = 5, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 8, SubtitleID = 6, ApplicationUserID = 2 });
			this.requests.Add(new Request { ID = 9, SubtitleID = 7, ApplicationUserID = 2 });

			this.comments = new List<Comment>();
			this.comments.Add(new Comment { ID = 1, SubtitleID = 4, Text = "Geggjað" });
			this.comments.Add(new Comment { ID = 2, SubtitleID = 4, Text = "WAT!" });
			this.comments.Add(new Comment { ID = 3, SubtitleID = 6, Text = "Ekki aftur?" });
			this.comments.Add(new Comment { ID = 4, SubtitleID = 2, Text = "No way!" });
		}
	}
}