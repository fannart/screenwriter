using Screenwriter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	public class HomeRepository
	{
		HomeContext db = new HomeContext();

		public int NumberOfRequests(int subtitleId)
		{
			int result = (from req in db.Requests
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
			var result = (from sub in db.Subtitles
						  where sub.LanguageID == id
						  select sub).AsQueryable();
			return result;
		}
		public Subtitle GetSubtitleById(int id)
		{
			var result = (from sub in db.Subtitles
						  where sub.ID == id
						  select sub).FirstOrDefault();
			return result;
		}
		public IQueryable<Language> GetAllLanguages()
		{
			var result = (from lang in db.Languages
						  select lang).AsQueryable();
			return result;
		}
		public IQueryable<Entry> GetAllEntiesBySubtitleId(int id)
		{
			var result = (from entry in db.Entries
						  where entry.SubtitleID == id
						  select entry).AsQueryable();
			return result;
		}
		public IQueryable<Media> GetAllMedia()
		{
			var result = (from m in db.Media
						  select m).AsQueryable();
			return result;
		}
		public void Save()
		{
			db.SaveChanges();
		}
	}
}