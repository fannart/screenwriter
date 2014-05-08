using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Screenwriter.DAL
{
	public class HomeContext : DbContext
	{
		public HomeContext() : base("HomeContext")
		{

		}

		public DbSet<Entry> Entries { get; set; }
		public DbSet<Subtitle> Subtitles { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Media> Media { get; set; }
		public DbSet<Request> Requests { get; set; }
		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}