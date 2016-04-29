using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class HandleCreator : BaseCreator<registry, StructDefinition>
	{
		public HandleCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 20)
		{
			//Off = true;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach(var structDefinition in Definitions)
			{
				structDefinition.TranslatedName = VulkanSpec.GetTranslatedName(structDefinition.SpecName);
				structDefinition.DerivedType = VulkanSpec.GetTranslatedName(structDefinition.SpecName);

				count++;
			}
			
			return 0;
		}

		public override int Build(IMapper mapper)
		{
			var registryHandles = VulkanSpec.SpecTree.types.Where(x => x.category == "handle");

			foreach (var registryHandle in registryHandles)
			{
				var structDefinition = mapper.Map<registryType, StructDefinition>(registryHandle);
				Definitions.Add(structDefinition);
			}

			return Definitions.Count;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var structDefinition in Definitions)
			{
				var output = new OutputDefinition() { FileName = structDefinition.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.OutputDirectory = "Handles";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				structDefinition.AddModifier(SyntaxKindDto.PublicKeyword);

				//foreach (var commentLine in classDefintion.Comments)
				//{
				//	output.CommentLines.Add(commentLine);
				//}

				output.AddStandardUsingDirective("System");

				(Generator as CSharpGenerator).GenerateStruct(output, structDefinition);
				count++;
			}

			return count;
		}
	}
}
