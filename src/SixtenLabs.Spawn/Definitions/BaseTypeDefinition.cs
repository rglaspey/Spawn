using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Type and Type Member definitions should derive from this base class.
	/// </summary>
	public abstract class BaseTypeDefinition : Definition
	{
		#region Constructors

		protected BaseTypeDefinition(string name)
			: base(name)
		{
		}

		#endregion

		#region Public Methods

		public void AddModifier(SyntaxKind modifier)
		{
			ModifierDefinitions.Add(new ModifierDefinition(modifier));
		}

		#endregion

		#region Properties

		/// <summary>
		/// Modifiers are used to modify declarations of types and type members
		/// </summary>
		public List<ModifierDefinition> ModifierDefinitions { get; } = new List<ModifierDefinition>();

		#endregion
	}
}
