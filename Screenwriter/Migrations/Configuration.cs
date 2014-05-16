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
			#region Languages
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
			#endregion
			
			#region Media
			context.Media.AddOrUpdate(
				new Media { ID = 1, LanguageID = 1, Type = 0, Title = "12 Years a Slave", publishDate = DateTime.Now },
				new Media { ID = 2, LanguageID = 1, Type = 0, Title = "Argo", publishDate = DateTime.Now },
				new Media { ID = 3, LanguageID = 1, Type = 0, Title = "The Artist", publishDate = DateTime.Now },
				new Media { ID = 4, LanguageID = 2, Type = 2, Title = "Verklegt námskeið 2014 - kynning", YoutubeIdentifier = "-02FatEYyLo", Lecturer = "Daníel Brandur Sigurgeirsson", School = "HR", publishDate = DateTime.Now },
				new Media { ID = 5, LanguageID = 3, Type = 1, Title = "One Piece", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1046719/", Season = 8, Episode = 1 },
				new Media { ID = 6, LanguageID = 3, Type = 0, Title = "Seven Samurai", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0047478/" },
				new Media { ID = 7, LanguageID = 3, Type = 0, Title = "Spirited Away", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt0245429/" },
				new Media { ID = 8, LanguageID = 2, Type = 1, Title = "The Night Watch", publishDate = DateTime.Now, ImdbURL = "//www.imdb.com/title/tt1823510/", Season = 1, Episode = 1 }
			);
			#endregion
			
			#region Subtitles
			context.Subtitles.AddOrUpdate(
				new Subtitle() { 
					ID = 1, 
					MediaID = 1,
					LanguageID = 2, 
					TranslationIsCompleted = true, 
					DownloadCount = 19, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 2, 
					MediaID = 3,
					LanguageID = 3, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 3, 
					MediaID = 1,
					LanguageID = 3, 
					TranslationIsCompleted = true,
					DownloadCount = 1337, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 4, 
					MediaID = 2,
					LanguageID = 1, 
					TranslationIsCompleted = true, 
					DownloadCount = 11, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 5, 
					MediaID = 1,
					LanguageID = 1, 
					TranslationIsCompleted = true, 
					DownloadCount = 3, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 6, 
					MediaID = 3,
					LanguageID = 1, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 7, 
					MediaID = 3,
					LanguageID = 2, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 8, 
					MediaID = 2,
					LanguageID = 3, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				},
				new Subtitle() { 
					ID = 9, 
					MediaID = 2,
					LanguageID = 2, 
					TranslationIsCompleted = false, 
					DownloadCount = 0, 
					LastUpdated = DateTime.Today, 
					DateCompleted = DateTime.Now 
				}
			);
			#endregion

			#region Entries
			context.Entries.AddOrUpdate(
				new Entry { ID = 1, SubtitleID = 1, Line1 = "Gott og vel nýju negrar.", Line2 = "Þið verðið partur af skurðarleiknum.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:08,600 --> 00:01:12,902" },
				new Entry { ID = 2, SubtitleID = 1, Line1 = "Mjög einfalt!", Line2 = "Ég vil að þið takið hnífinn ykkar..", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:13,100 --> 00:01:15,802" },
				new Entry { ID = 3, SubtitleID = 4, Line1 = "ARGO", Line2 = "where no text had been before", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:00:33,088 --> 00:00:36,088" },
				new Entry { ID = 4, SubtitleID = 1, Line1 = "takið í reyrinn,", Line2 = "og látið hann syngja.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:16,000 --> 00:01:19,802" },
				new Entry { ID = 5, SubtitleID = 1, Line1 = "Takið reyrinn af.", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:20,000 --> 00:01:21,802" },
				new Entry { ID = 6, SubtitleID = 4, Line1 = "This is the Persian Empire", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:00:38,750 --> 00:00:40,597" },
				new Entry { ID = 7, SubtitleID = 4, Line1 = "known today as Iran.", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:00:41,278 --> 00:00:43,073" },
				new Entry { ID = 8, SubtitleID = 1, Line1 = "Skerið ofan af og hreinsið stilkana af.", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:22,000 --> 00:01:25,852" },
				new Entry { ID = 9, SubtitleID = 1, Line1 = "Safnið honum í hrúgu þar sem", Line2 = "hann verður settur niður aftur.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:26,050 --> 00:01:29,402" },
				new Entry { ID = 10, SubtitleID = 3, Line1 = "実話に基づいた映画", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:00:54,600 --> 00:00:58,911" },
				new Entry { ID = 11, SubtitleID = 3, Line1 = "よし いいか！新米", Line2 = "切り方のお手本だ", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:08,600 --> 00:01:12,911" },
				new Entry { ID = 12, SubtitleID = 3, Line1 = "誰でもできる", Line2 = "ナイフを持って...", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:13,100 --> 00:01:15,868" },
				new Entry { ID = 13, SubtitleID = 3, Line1 = "茎を持ち上げ", Line2 = "束にして", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:16,000 --> 00:01:19,900" },
				new Entry { ID = 14, SubtitleID = 5, Line1 = "All right now.", Line2 = "Y'all fresh niggers.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:10,112 --> 00:01:12,530" },
				new Entry { ID = 15, SubtitleID = 5, Line1 = "Y'all gonna be", Line2 = "in a cutting gang.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:12,698 --> 00:01:14,240" },
				new Entry { ID = 16, SubtitleID = 5, Line1 = "Very simple. I want", Line2 = "you to take your knife.", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:14,658 --> 00:01:17,451" },
				new Entry { ID = 17, SubtitleID = 5, Line1 = "Get in them cane.", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:17,619 --> 00:01:19,370" },
				new Entry { ID = 18, SubtitleID = 5, Line1 = "Make it sing.", Line2 = "", StartTime = DateTime.Now, Stoptime = DateTime.Now, TimeStamp = "00:01:20,038 --> 00:01:21,414" }
			);
			#endregion

			#region Requests
			context.Requests.AddOrUpdate(
				new Request { ID = 1, SubtitleID = 1, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 2, SubtitleID = 2, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 3, SubtitleID = 3, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 4, SubtitleID = 4, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 5, SubtitleID = 5, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 6, SubtitleID = 6, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 7, SubtitleID = 7, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 8, SubtitleID = 8, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 9, SubtitleID = 9, UserID = "d10c617e-639c-4814-9b46-7fc3f0f0b9ba" },
				new Request { ID = 10, SubtitleID = 5, UserID = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9" },
				new Request { ID = 11, SubtitleID = 6, UserID = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9" },
				new Request { ID = 12, SubtitleID = 7, UserID = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9" },
				new Request { ID = 13, SubtitleID = 1, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 14, SubtitleID = 2, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 15, SubtitleID = 3, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 16, SubtitleID = 5, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 17, SubtitleID = 6, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 18, SubtitleID = 7, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 19, SubtitleID = 8, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 20, SubtitleID = 9, UserID = "c3c79177-c029-4051-9d57-c2c0c86e8831" },
				new Request { ID = 21, SubtitleID = 6, UserID = "a68a9d38-0e2a-42a0-864c-dc706c60500d" },
				new Request { ID = 22, SubtitleID = 5, UserID = "a68a9d38-0e2a-42a0-864c-dc706c60500d" },
				new Request { ID = 23, SubtitleID = 3, UserID = "a68a9d38-0e2a-42a0-864c-dc706c60500d" },
				new Request { ID = 24, SubtitleID = 6, UserID = "95e26a86-113a-4978-9557-39755ab1fef7" },
				new Request { ID = 25, SubtitleID = 3, UserID = "95e26a86-113a-4978-9557-39755ab1fef7" },
				new Request { ID = 26, SubtitleID = 5, UserID = "95e26a86-113a-4978-9557-39755ab1fef7" }
			);
			#endregion

			#region Comments
			context.Comments.AddOrUpdate(
				new Comment() { ID = 1, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9", Text = "Geggjað" },
				new Comment() { ID = 2, SubtitleID = 4, TimeStamp = DateTime.Now, UserId = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9", Text = "WAT!" },
				new Comment() { ID = 3, EntryID = 1, TimeStamp = DateTime.Now, UserId = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9", Text = "Ekki aftur?" },
				new Comment() { ID = 4, EntryID = 1, TimeStamp = DateTime.Now, UserId = "cbbfc2b4-6a3b-4a7d-80be-61e6d2f185e9", Text = "No way!" }
			);
			#endregion
		}
    }
}
