namespace Screenwriter.Migrations
{
	using Screenwriter.Models;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Screenwriter.DAL.HomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Screenwriter.DAL.HomeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
			//
			var languages = new List<Language>
			{
				new Language { ID = 1, Name = "English" },
				new Language { ID = 2, Name = "Icelandic" },
				new Language { ID = 3, Name = "Japanese" }
			};

			languages.ForEach(l => context.Languages.Add(l));
			context.SaveChanges();

			var media = new List<Media>
			{
				new Movie{ID = 1, LanguageID = 1, Title = "12 Years a Slave"},
				new Movie{ID = 2, LanguageID = 1, Title = "Argo"},
				new Movie{ID = 3, LanguageID = 1, Title = "The Artist"}
			};

			media.ForEach(m => context.Media.Add(m));
			context.SaveChanges();


			var subtitles = new List<Subtitle>
			{
				new Subtitle { ID = 1, MediaID = 1, LanguageID = 2, TranslationIsCompleted = true, DownloadCount = 19, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 2, MediaID = 3, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 3, MediaID = 1, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 4, MediaID = 2, LanguageID = 1, TranslationIsCompleted = true, DownloadCount = 11, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 5, MediaID = 1, LanguageID = 1, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 6, MediaID = 3, LanguageID = 1, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 7, MediaID = 3, LanguageID = 2, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 8, MediaID = 2, LanguageID = 3, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now },
				new Subtitle { ID = 9, MediaID = 2, LanguageID = 2, TranslationIsCompleted = false, DownloadCount = 0, DateAdded = DateTime.Today, lastUpdated = DateTime.Today, DateCompleted = DateTime.Now }
			};

			subtitles.ForEach(s => context.Subtitles.Add(s));
			context.SaveChanges();

			var entries = new List<Entry>
			{
				new Entry { ID = 1, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 2, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 3, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 4, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 5, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 6, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 7, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 8, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 9, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now }
			};

			entries.ForEach(e => context.Entries.Add(e));
			context.SaveChanges();

			var requests = new List<Request>
			{
				new Request { ID = 1, SubtitleID = 2, ApplicationUserID = 1 },
				new Request { ID = 2, SubtitleID = 1, ApplicationUserID = 2 },
				new Request { ID = 3, SubtitleID = 3, ApplicationUserID = 1 },
				new Request { ID = 4, SubtitleID = 2, ApplicationUserID = 2 },
				new Request { ID = 5, SubtitleID = 3, ApplicationUserID = 2 },
				new Request { ID = 6, SubtitleID = 4, ApplicationUserID = 2 },
				new Request { ID = 7, SubtitleID = 5, ApplicationUserID = 2 },
				new Request { ID = 8, SubtitleID = 6, ApplicationUserID = 2 },
				new Request { ID = 9, SubtitleID = 7, ApplicationUserID = 2 }
			};

			requests.ForEach(r => context.Requests.Add(r));
			context.SaveChanges();

			ApplicationDbContext appContext = new ApplicationDbContext();

			var comments = new List<Comment>
			{
				new Comment { ID = 1, User = appContext.Users.Last(), SubtitleID = 4, Text = "Geggjað" },
				new Comment { ID = 2, User = appContext.Users.Last(), SubtitleID = 4, Text = "WAT!" },
				new Comment { ID = 3, User = appContext.Users.Last(), SubtitleID = 6, Text = "Ekki aftur?" },
				new Comment { ID = 4, User = appContext.Users.Last(), SubtitleID = 2, Text = "No way!" }
			};

			comments.ForEach(c => context.Comments.Add(c));
			context.SaveChanges();
        }
    }
}
