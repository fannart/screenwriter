using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	public class Lecture : Media
	{
		public string Course { get; set; }
		public string School { get; set; }
		public string Lecturer { get; set; }
	}
}