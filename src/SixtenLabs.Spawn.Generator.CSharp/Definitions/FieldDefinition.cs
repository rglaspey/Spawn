using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public class FieldDefinition : BaseDefinition
	{
		public FieldDefinition()
		{
		}

		public string SpecType { get; set; }

		public string TranslatedType { get; set; }

		public string SpecValue { get; set; }

		public string TranslatedValue { get; set; }

		public List<CommentLineDefinition> Comments { get; } = new List<CommentLineDefinition>();

		public List<ModifierDefinition> Modifiers { get; } = new List<ModifierDefinition>();
	}
}
