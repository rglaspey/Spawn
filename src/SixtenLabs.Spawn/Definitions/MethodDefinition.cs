using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public class MethodDefinition : Definition
	{
		public MethodDefinition()
		{
		}

		public void AddModifier(Modifiers modifier, int order)
		{
			Modifiers.Add(new ModifierDefinition() { Modifier = modifier, Order = order });
		}

		public string SpecReturnType { get; set; }

		public string TranslatedReturnType { get; set; }

		public List<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();

		public List<AttributeDefinition> Attributes { get; } = new List<AttributeDefinition>();

		public List<ModifierDefinition> Modifiers { get; } = new List<ModifierDefinition>();

		public List<string> Comments { get; set; } = new List<string>();
	}
}
