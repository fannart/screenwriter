using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a single comment to a Subtitle or Entry.</summary>
	public class Comment
	{
		public int ID { get; set; }
		public int? EntryID { get; set; }
		public int? SubtitleID { get; set; }
		public string UserId { get; set; }
		public string Text { get; set; }
		public DateTime TimeStamp { get; set; }

		public virtual Entry Entry { get; set; }
		public virtual Subtitle Subtitle { get; set; }

		public Comment()
		{
			TimeStamp = DateTime.Now;
		}
		public Comment(string comment) : this()
		{
			Text = comment;
		}
	}
}