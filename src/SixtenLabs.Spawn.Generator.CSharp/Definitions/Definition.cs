using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	/// <summary>
	/// Base definition. Holds all common functionality for concrete definitions
	/// </summary>
  public abstract class Definition
  {
    public Definition()
    {
    }

    public string SpecName { get; set; }

		private string translatedName;

		public string TranslatedName
		{
			get
			{
				if (string.IsNullOrEmpty(translatedName))
				{
					return SpecName;
				}
				else
				{
					return translatedName;
				}
			}

			set
			{
				translatedName = value;
			}
		}

		/// <summary>
		/// Use this to capture any information your spec may need.
		/// This would typically be used at the level where your processing
		/// your data before asking the Csharp Generator to generate.
		/// The CSharp generator does not use this field.
		/// </summary>
		public string Tag { get; set; }
  }
}
