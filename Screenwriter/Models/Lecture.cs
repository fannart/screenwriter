using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents an lecture, an educational branch of the Media class.</summary>
	public class Lecture : Media
	{
		/// <summary>
		/// The course in which the lecture was given.</summary>
		public string Course { get; set; }
		/// <summary>
		/// The school in which the lecture was given.</summary>
		public string School { get; set; }
		/// <summary>
		/// The lecturer who gave the lecture.</summary>
		public string Lecturer { get; set; }
	}
}