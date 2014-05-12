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

		public void AddRequest(int subtitleId, string userId)
		{
			db.Requests.Add(new Request { SubtitleID = subtitleId, UserID = userId });
			db.SaveChanges();
		}

		public bool RequestExists(int subtitleId, string userId)
		{
			var requests = from req in db.Requests
						   select req;
			int result = (from req in db.Requests
						  where req.SubtitleID == subtitleId
						  && req.UserID == userId
						  select req).Count();
			bool res = result > 0;
			return res;
		}

		public int NumberOfRequests(int subtitleId)
		{
			int result = (from req in db.Requests
						  where req.SubtitleID == subtitleId
						  select req).Count();
			return result;
		}

		public IQueryable<Subtitle> GetAllSubtitles()
		{
			var result = db.Subtitles.AsQueryable();
			
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
						  orderby lang.Name ascending
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
			var result = db.Media.AsQueryable();
			return result;
		}
		public Media GetMediaById(int id)
		{
			var result = (from m in db.Media
						  where m.ID == id
						  select m).SingleOrDefault();
			return result;
		}
		public void Save()
		{
			db.SaveChanges();
		}
	}
}