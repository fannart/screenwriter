using Screenwriter.Models;
using Screenwriter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.Controllers
{
	[Authorize]
    public class EditorController : Controller
    {
		[HttpPost]
		public void UpdateEntry(Entry entry)
		{
			if (ModelState.IsValid)
			{
				HomeRepository repo = new HomeRepository();
				repo.UpdateEntry(entry);
			}
		}

		public ActionResult ReferenceLanguage(int id)
		{
			HomeRepository repo = new HomeRepository();
			int subtitleID = id;
			Subtitle model = repo.GetSubtitleById(id);
			return PartialView("ReferenceWindow", model);
		}

        // GET: /Editor/Subtitle/
        public ActionResult Subtitle(int? id)
        {
			if(id.HasValue)
			{
				EditorViewModel model = new EditorViewModel();
				HomeRepository repo = new HomeRepository();
				int subtitleID = id.Value;

				Subtitle translateSubtitle = repo.GetSubtitleById(subtitleID);

				int mediaID = translateSubtitle.MediaID;
				Media media = repo.GetMediaById(mediaID);

				model.Media = media;

				model.ReferenceLanguages = new List<SelectLanguage>();
				model.LanguageDropDownList = new List<SelectListItem>();
				List<Subtitle> existingSubtitles = repo.GetAllSubtitles()
					.Where(s => s.TranslationIsCompleted
					&& s.MediaID == mediaID
					)
					// TODO: UNCOMMENT THIS --> && s.ID != translateSubtitle.ID)
					.ToList();
				foreach(var sub in existingSubtitles)
				{
					Language language = repo.GetLanguageById(sub.LanguageID);
					model.ReferenceLanguages.Add(new SelectLanguage { 
						ReferenceLanguage = language, 
						SubtitleID = sub.ID 
					});
					model.LanguageDropDownList.Add(new SelectListItem { 
						Value = sub.ID.ToString(),
						Text = language.Name
					});
				}

				model.ReferenceSubtitle = existingSubtitles.FirstOrDefault();
				model.WorkingSubtitle = repo.GetSubtitleById(subtitleID);
				model.WorkingLanguage = repo.GetLanguageById(model.WorkingSubtitle.LanguageID);

				return View(model);
			}
            return View("Error");
        }
	}
}