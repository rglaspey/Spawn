using SixtenLabs.Spawn.Utility;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class StructCreator : BaseCreator<registry, StructDefinition>
	{
		public StructCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 40)
		{
		}

		public override int Rewrite()
		{
			int count = 0;

			return count;
		}

		public override int Build()
		{
			var registryStructs = VulkanSpec.SpecTree.types.Where(x => x.category == "struct");

			foreach (var registryStruct in registryStructs)
			{
				var structDefinition = new StructDefinition();

				structDefinition.SpecName = registryStruct.name;
				structDefinition.TranslatedName = VulkanSpec.FindTypeDefinition(registryStruct.name).TranslatedName;

				foreach(var item in registryStruct.Items)
				{
					if (item is registryTypeMember)
					{
						var member = item as registryTypeMember;
						structDefinition.AddField(member.name, member.name, member.type, VulkanSpec.FindTypeDefinition(member.type).TranslatedName);
					}
					else if(item is registryTypeValidity)
					{
						var validity = item as registryTypeValidity;

						foreach(var usage in validity.usage)
						{
							structDefinition.Comments.Add(usage);
						}
					}
				}

				Definitions.Add(structDefinition);
			}

			return Definitions.Count;
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