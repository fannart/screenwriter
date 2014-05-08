using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a request by a user for a specific subtitle.</summary>
	public class Request
	{
		public int ID { get; set; }
		public int SubtitleID { get; set; }
		public int ApplicationUserID { get; set; }

		public virtual Subtitle Subtitle { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}