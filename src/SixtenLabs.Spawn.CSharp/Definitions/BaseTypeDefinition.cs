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

		public string TranslatedReturnType { get; set; }
		
		/// <summary>
		/// Modifiers are used to modify declarations of types and type members
		/// </summary>
		public List<ModifierDefinition> ModifierDefinitions { get; } = new List<ModifierDefinition>();
	}
}
