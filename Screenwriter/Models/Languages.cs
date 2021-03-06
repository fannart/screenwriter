﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Screenwriter.Models
{
    /// <summary>
    /// Represents a language.</summary>
    public class Languages
    {
        public int ID { get; set; }
        /// <summary>
        /// A string containing the name of the language.</summary>
        public string Name { get; set; }
        /// <summary>
        /// Short version of the name for identification.</summary>
        public string ShortName { get; set; }
    }
}