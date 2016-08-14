using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.CSharp
{
	/// <summary>
	/// Type and Type Member definitions should derive from this base class.
	/// </summary>
	public abstract class BaseTypeDefinition : Definition
	{
		protected BaseTypeDefinition()
		{
		}

		public void AddModifier(SyntaxKindDto modifier)
		{
			ModifierDefinitions.Add(new ModifierDefinition() { Modifier = modifier });
		}
		
		public string SpecReturnType { get; set; }

		private string translatedReturnType;

		public string TranslatedReturnType
		{
			get
			{
				if(string.IsNullOrEmpty(translatedReturnType))
				{
					return SpecReturnType;
				}
				else
				{
					return translatedReturnType;
				}
			}

			set
			{
				translatedReturnType = value;
			}
		}
		
		/// <summary>
		/// Modifiers are used to modify declarations of types and type members
		/// </summary>
		public List<ModifierDefinition> ModifierDefinitions { get; set; } = new List<ModifierDefinition>();
	}
}
