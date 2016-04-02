namespace SixtenLabs.Spawn
{
	public class CSharpGenerator : CodeGenerator
	{
		public CSharpGenerator(ISpawnService spawn, IXmlSerializer serializer)
			: base(spawn, serializer)
		{
		}

		/// <summary>
		/// Generate a single output with an enum
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="enumDefinition"></param>
		/// <returns></returns>
		public override void GenerateCodeFile<T>(OutputDefinition<T> outputDefinition)
		{
			var xml = SerializeData(outputDefinition, "output");
			var contents = TransformXmlFromTemplate(outputDefinition.TemplateName, xml);

			Spawn.AddDocumentToProject(outputDefinition.TargetSolution, outputDefinition.FileName, contents, new string[] { outputDefinition.OutputDirectory });
		}
	}
}
