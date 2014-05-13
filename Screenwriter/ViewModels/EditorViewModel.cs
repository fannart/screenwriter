using Screenwriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.ViewModels
{
	public class EditorViewModel
	{
		Subtitle TranslateFrom { get; set; }
		Subtitle TranslateTo { get; set; }
	}
}