using SixtenLabs.Spawn.Utility;
using System.Linq;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class StructCreator : BaseCreator<registry, StructDefinition>
	{
		public StructCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 40)
		{
		}

		//private StructDefinition ReadStruct(registryType structElement)
		//{
		//	var structDefinition = new StructDefinition();

		//	var specName = structElement.name;
		//	var name = specName.TranslateVulkanName();

		//	structDefinition.SpecName = specName;
		//	structDefinition.Name = name;

		//	var structMembers = structElement.Items;

		//	foreach (var structMember in structMembers)
		//	{
		//		//var memberSpecName = structMember.Element("name").Value;
		//		//var memberName = memberSpecName.TranslateVulkanName();
		//		//var memberSpecType = structMember.Element("type").Value;

		//		//structDefinition.AddField(memberSpecName, memberName, memberSpecType);
		//	}

		//	return structDefinition;
		//}

		public override int Rewrite()
		{
			int count = 0;

			//foreach (var structDefinition in Definitions)
			//{
			//	foreach (var field in structDefinition.Fields)
			//	{
			//		if (VulkanSpec.AllTypes.ContainsKey(field.SpecType))
			//		{
			//			field.Type = VulkanSpec.AllTypes[field.SpecType];
			//		}
			//		else
			//		{
			//			field.Type = "Heffalump";
			//		}
			//	}

			//	count++;
			//}

			return count;
		}

		public override int Build()
		{
			return 0;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var structDefinition in Definitions)
			{
				var output = new OutputDefinition<StructDefinition>() { FileName = structDefinition.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.TemplateName = "StructTemplate";
				output.OutputDirectory = "Structs";
				output.AddStandardUsingDirective("System");

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				foreach (var commentLine in structDefinition.Comments)
				{
					output.CommentLines.Add(commentLine);
				}

				output.TypeDefinitions.Add(structDefinition);
				
				Generator.GenerateCodeFile(output);
				count++;
			}

			return count;
		}
	}
}