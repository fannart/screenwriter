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
			AutomaticMigrationDataLossAllowed = true;
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
				new Language { ID = 1, ShortName = "gb", Name = "English" },
				new Language { ID = 2, ShortName = "is", Name = "Icelandic" },
				new Language { ID = 3, ShortName = "jp", Name = "Japanese" },
				new Language { ID = 4, ShortName = "cn", Name = "Chinese" },
				new Language { ID = 5, ShortName = "de", Name = "German" },
				new Language { ID = 6, ShortName = "dk", Name = "Danish" },
				new Language { ID = 7, ShortName = "es", Name = "Spanish" },
				new Language { ID = 8, ShortName = "fi", Name = "Finnish" },
				new Language { ID = 9, ShortName = "fo", Name = "Faroese" },
				new Language { ID = 10, ShortName = "fr", Name = "France" },
				new Language { ID = 11, ShortName = "it", Name = "Italian" },
				new Language { ID = 12, ShortName = "mt", Name = "Maltese" },
				new Language { ID = 13, ShortName = "no", Name = "Norweigian" },
				new Language { ID = 14, ShortName = "pl", Name = "Polish" },
				new Language { ID = 15, ShortName = "pt", Name = "Portugese" },
				new Language { ID = 16, ShortName = "ru", Name = "Russian" },
				new Language { ID = 17, ShortName = "se", Name = "Swedish" }
			);

			context.Media.AddOrUpdate(
				new Media { ID = 1, LanguageID = 1, Type = 0, Title = "12 Years a Slave", publishDate = DateTime.Now },
				new Media { ID = 2, LanguageID = 1, Type = 0, Title = "Argo", publishDate = DateTime.Now },
				new Media { ID = 3, LanguageID = 1, Type = 0, Title = "The Artist", publishDate = DateTime.Now },
				new Media { ID = 4, LanguageID = 2, Type = 2, Title = "Verklegt n�mskei� 2014 - kynning", YoutubeIdentifier = "-02FatEYyLo", Lecturer = "Dan�el Brandur Sigurgeirsson", School = "HR", publishDate = DateTime.Now },
				new Media { ID = 5, LanguageID = 3, Type = 1, Title = "One Piece", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1046719/", Season = 8, Episode = 1 },
				new Media { ID = 6, LanguageID = 3, Type = 0, Title = "Seven Samurai", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0047478/" },
				new Media { ID = 7, LanguageID = 3, Type = 0, Title = "Spirited Away", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0245429/" },
				new Media { ID = 8, LanguageID = 2, Type = 1, Title = "The Night Watch", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1823510/", Season = 1, Episode = 1 }
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
			/*
			context.Requests.AddOrUpdate(
				new Request { ID = 1, SubtitleID = 1, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" },
				new Request { ID = 2, SubtitleID = 2, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" },
				new Request { ID = 3, SubtitleID = 3, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" },
				new Request { ID = 4, SubtitleID = 4, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" },
				new Request { ID = 5, SubtitleID = 5, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" },
				new Request { ID = 6, SubtitleID = 6, UserID = "1a3aa749-267b-4123-b921-9f6ed1d91ee8" }
			);
			/*
				new Request { ID = 7, SubtitleID = 5, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 8, SubtitleID = 6, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 9, SubtitleID = 7, UserID = "d8b7faf3-a9f3-4c18-8398-edefb021a688" },
				new Request { ID = 10, SubtitleID = 1, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 11, SubtitleID = 2, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 12, SubtitleID = 3, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 13, SubtitleID = 5, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 14, SubtitleID = 7, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 15, SubtitleID = 3, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 16, SubtitleID = 5, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 17, SubtitleID = 6, UserID = "8104a076-a79b-43ad-b538-cfc8dcb3adc3" },
				new Request { ID = 18, SubtitleID = 6, UserID = "921cb03a-3f37-4f17-8dc3-f82f8b7bd58c" },
				new Request { ID = 19, SubtitleID = 5, UserID = "921cb03a-3f37-4f17-8dc3-f82f8b7bd58c" },
				new Request { ID = 20, SubtitleID = 3, UserID = "921cb03a-3f37-4f17-8dc3-f82f8b7bd58c" },
				new Request { ID = 21, SubtitleID = 6, UserID = "fc814617-65ea-4fa2-a39f-e70c54fe5c31" },
				new Request { ID = 22, SubtitleID = 3, UserID = "fc814617-65ea-4fa2-a39f-e70c54fe5c31" },
				new Request { ID = 23, SubtitleID = 5, UserID = "fc814617-65ea-4fa2-a39f-e70c54fe5c31" }
			);
			
			context.Comments.AddOrUpdate(
				new Comment() { ID = 1, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "Geggja�" },
				new Comment() { ID = 2, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "WAT!" },
				new Comment() { ID = 3, EntryID = 1, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "Ekki aftur?" },
				new Comment() { ID = 4, EntryID = 1, TimeStamp = DateTime.Now, UserId = "d8b7faf3-a9f3-4c18-8398-edefb021a688", Text = "No way!" }
			);
			*/
		}
    }
}
