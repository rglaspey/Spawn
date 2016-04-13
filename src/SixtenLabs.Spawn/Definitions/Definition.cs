﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Base definition. Holds all common functionality for concrete definitions
	/// </summary>
  public abstract class Definition
  {
    public Definition()
    {
    }

		/// <summary>
		/// The name used in the spec we are generating from.
		/// </summary>
		public string SpecName { get; set; }

		/// <summary>
		/// The translated name that will be used in the generated output.
		/// </summary>
		public string TranslatedName { get; set; }
	}
}
