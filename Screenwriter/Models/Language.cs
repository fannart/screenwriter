using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
	/// <summary>
	/// Represents a language.</summary>
	public class Language
	{
		public int ID { get; set; }
		/// <summary>
		/// A string containing the name of the language.</summary>
		public string Name { get; set; }
		// TODO: how to store an image in the database
		// public System.Drawing.Image Flag { get; set; }
	}
}