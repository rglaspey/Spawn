namespace SixtenLabs.Spawn
{
	/// <summary>
	/// This is used to keep track of all the names from 
	/// the spec that is being converted, and all of the translations
	/// for the converted output. This allows for changing the names in
	/// the spec to be more aligned with the language or conventions
	/// of the generated code.
	/// </summary>
	public class SpecTypeDefinition : IDefinition
	{
		public string SpecName { get; set; }

		public string TranslatedName { get; set; }
	}
}
