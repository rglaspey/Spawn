namespace SixtenLabs.Spawn
{
	public class ConstantDefinition : Definition
	{
		public ModifierDefinition Modifier { get; set; }
		
		public string SpecType { get; set; }

		public string TranslatedType { get; set; }

		public string Value { get; set; }
	}
}
