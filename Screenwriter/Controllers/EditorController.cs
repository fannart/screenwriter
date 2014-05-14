using Screenwriter.Models;
using Screenwriter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.Controllers
{
    public class EditorController : Controller
    {
        // GET: /Editor/Subtitle/
		[Authorize]
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
					&& s.MediaID == mediaID)
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

				model.WorkingSubtitle = repo.GetSubtitleById(subtitleID);
				model.WorkingLanguage = repo.GetLanguageById(model.WorkingSubtitle.LanguageID);

				return View(model);
			}
            return View("Error");
        }
	}
}