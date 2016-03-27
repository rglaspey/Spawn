namespace SixtenLabs.Spawn
{
	public class CSharpGenerator : CodeGenerator
	{
		public CSharpGenerator(ISpawnService spawn)
			: base(spawn)
		{
		}

		/// <summary>
		/// Generate a single output with an enum
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="enumDefinition"></param>
		/// <returns></returns>
		public override void GenerateEnum(EnumDefinition enumDefinition, OutputDefinition outputDefinition)
		{
			var xml = SerializeDefinition(enumDefinition);
			var template = LoadTemplate("EnumTemplate");
			var contents = TransformXmlFromTemplate(xml, template);

			Spawn.AddDocumentToProject(outputDefinition.TargetSolution, enumDefinition.Name, contents, new string[] { "Enums" });
		}
	}
}
