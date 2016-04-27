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
  }
}
