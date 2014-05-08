using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.DAL
{
	public class HomeInitializer : System.Data.Entity.DropCreateDatabaseAlways<HomeContext>
	{
		protected override void Seed(HomeContext context)
		{
			var media = new List<Media>
			{
				new Movie{ID = 1, Title = "12 Years a Slave"},
				new Movie{ID = 2, Title = "Argo"},
				new Movie{ID = 3, Title = "The Artist"}
			};

			media.ForEach(m => context.Media.Add(m));
			context.SaveChanges();
		}
	}
}