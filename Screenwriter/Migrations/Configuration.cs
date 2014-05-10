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
			AutomaticMigrationDataLossAllowed = false;
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

			context.Languages.AddOrUpdate(
				new Language { ID = 1, Name = "English" },
				new Language { ID = 2, Name = "Icelandic" },
				new Language { ID = 3, Name = "Japanese" }
			);

			context.Media.AddOrUpdate(
				new Movie { ID = 1, LanguageID = 1, Title = "12 Years a Slave", publishDate = DateTime.Now },
				new Movie { ID = 2, LanguageID = 1, Title = "Argo", publishDate = DateTime.Now },
				new Movie { ID = 3, LanguageID = 1, Title = "The Artist", publishDate = DateTime.Now },
				new Lecture { ID = 4, LanguageID = 2, Title = "Verklegt námskeið 2014 - kynning", YoutubeIdentifier = "-02FatEYyLo", Lecturer = "Daníel Brandur Sigurgeirsson", School = "HR", publishDate = DateTime.Now },
				new TVShow { ID = 5, LanguageID = 3, Title = "One Piece", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1046719/", Season = 8, Episode = 1 },
				new Movie { ID = 6, LanguageID = 3, Title = "Seven Samurai", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0047478/" },
				new Movie { ID = 7, LanguageID = 3, Title = "Spirited Away", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0245429/" },
				new TVShow { ID = 8, LanguageID = 2, Title = "The Night Watch", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1823510/", Season = 1, Episode = 1 }
			);

			context.Subtitles.AddOrUpdate(
				new Subtitle() { 
					ID = 1, 
					MediaID = 1, 
					LanguageID = 2, 
					TranslationIsCompleted = true, 
					DownloadCount = 19, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 2, 
					MediaID = 3, 
					LanguageID = 3, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 3, 
					MediaID = 1, 
					LanguageID = 3, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 4, 
					MediaID = 2, 
					LanguageID = 1, 
					TranslationIsCompleted = true, 
					DownloadCount = 11, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 5, 
					MediaID = 1, 
					LanguageID = 1, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 6, 
					MediaID = 3, 
					LanguageID = 1, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 7, 
					MediaID = 3, 
					LanguageID = 2, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 8, 
					MediaID = 2, 
					LanguageID = 3, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 9, 
					MediaID = 2, 
					LanguageID = 2, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					lastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				}
			);

			context.Entries.AddOrUpdate(
				new Entry { ID = 1, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 2, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 3, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 4, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 5, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 6, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 7, SubtitleID = 4, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 8, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now },
				new Entry { ID = 9, SubtitleID = 1, Line1 = "Text", Line2 = "More Text", StartTime = DateTime.Now, Stoptime = DateTime.Now }
			);

			context.Requests.AddOrUpdate(
				new Request { ID = 1, SubtitleID = 2, UserID = "e99ed7d6-69ee-4902-b751-e90e49504620" },
				new Request { ID = 2, SubtitleID = 1, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 3, SubtitleID = 3, UserID = "e99ed7d6-69ee-4902-b751-e90e49504620" },
				new Request { ID = 4, SubtitleID = 2, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 5, SubtitleID = 3, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 6, SubtitleID = 4, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 7, SubtitleID = 5, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 8, SubtitleID = 6, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 9, SubtitleID = 7, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" }
			);
			
			context.Comments.AddOrUpdate(
				new Comment() { ID = 1, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "Geggjað" },
				new Comment() { ID = 2, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "WAT!" },
				new Comment() { ID = 3, EntryID = 1, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "Ekki aftur?" },
				new Comment() { ID = 4, EntryID = 1, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "No way!" }
			);
        }
    }
}
