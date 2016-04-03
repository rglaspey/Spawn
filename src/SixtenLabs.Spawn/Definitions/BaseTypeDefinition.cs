using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Type and Type Member definitions should derive from this base class.
	/// </summary>
	public abstract class BaseTypeDefinition : Definition
	{
		protected BaseTypeDefinition()
		{
		}

		public void AddModifier(Modifiers modifier, int order)
		{
			ModifierDefinitions.Add(new ModifierDefinition() { Modifier = modifier, Order = order });
		}

		/// <summary>
		/// Modifiers are used to modify declarations of types and type members
		/// </summary>
		public List<ModifierDefinition> ModifierDefinitions { get; } = new List<ModifierDefinition>();
	}
}
