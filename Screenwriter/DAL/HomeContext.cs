using Microsoft.AspNet.Identity.EntityFramework;
using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Screenwriter.DAL
{
	public class HomeContext : IdentityDbContext
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
		public DbSet<MediaGenre> MediaGenre { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Comment>()
				.HasOptional(p => p.Entry)
				.WithMany(p => p.Comments)
				.HasForeignKey(p => p.EntryID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Comment>()
				.HasOptional(p => p.Subtitle)
				.WithMany(p => p.Comments)
				.HasForeignKey(p => p.SubtitleID)
				.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}