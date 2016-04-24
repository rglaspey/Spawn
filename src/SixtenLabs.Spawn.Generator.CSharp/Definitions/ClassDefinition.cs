using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public class ClassDefinition : BaseDefinition
	{
		public void AddModifier(Modifiers modifier, int order)
		{
			Modifiers.Add(new ModifierDefinition() { Modifier = modifier, Order = order });
		}

		public string SpecDerivedType { get; set; }

		public string DerivedType { get; set; }

		public IList<FieldDefinition> Fields { get; } = new List<FieldDefinition>();

		public List<MethodDefinition> Methods { get; } = new List<MethodDefinition>();

		public List<ModifierDefinition> Modifiers { get; } = new List<ModifierDefinition>();

		public List<string> Comments { get; set; } = new List<string>();
	}
}
