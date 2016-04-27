using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class HandleCreator : BaseCreator<registry, ClassDefinition>
	{
		public HandleCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 20)
		{
			Off = true;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach(var classDefinition in Definitions)
			{
				classDefinition.TranslatedName = VulkanSpec.GetTranslatedName(classDefinition.SpecName);
				classDefinition.DerivedType = VulkanSpec.GetTranslatedName(classDefinition.SpecName);

				count++;
			}
			
			return 0;
		}

		public override int Build(IMapper mapper)
		{
			var registryHandles = VulkanSpec.SpecTree.types.Where(x => x.category == "handle");

			foreach (var registryHandle in registryHandles)
			{
				var classDefinition = mapper.Map<registryType, ClassDefinition>(registryHandle);
				Definitions.Add(classDefinition);
			}

			return Definitions.Count;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var classDefinition in Definitions)
			{
				var output = new OutputDefinition() { FileName = classDefinition.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.OutputDirectory = "Handles";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				//foreach (var commentLine in classDefintion.Comments)
				//{
				//	output.CommentLines.Add(commentLine);
				//}

				output.AddStandardUsingDirective("System");

				(Generator as CSharpGenerator).GenerateClass(output, classDefinition);
				count++;
			}

			return count;
		}
	}
}
