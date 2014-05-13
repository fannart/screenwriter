using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Screenwriter.Controllers
{
    public class EditorController : Controller
    {
        //
        // GET: /Editor/
        public ActionResult Subtitle(int? id)
        {
			if(id.HasValue)
			{
				HomeRepository repo = new HomeRepository();
				int subtitleID = id.Value;
				

				return View();
			}
            return View("Error");
        }
	}
}