using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class ConstantsCreator : BaseCreator<registry, ClassDefinition>
	{
		public ConstantsCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 9)
		{
		}

		public override int Build(IMapper mapper)
		{
			var registryConstants = VulkanSpec.SpecTree.enums.Where(x => x.name == "API Constants");

			foreach (var registryConstant in registryConstants)
			{
				var classDefinition = mapper.Map<registryEnums, ClassDefinition>(registryConstant);

				classDefinition.AddModifier(SyntaxKindDto.PublicKeyword);
				classDefinition.AddModifier(SyntaxKindDto.StaticKeyword);
				classDefinition.SpecName = registryConstant.name;
				
				// This is hardcoded for this single enum exception.
				classDefinition.TranslatedName = "ApiConstants";

				Definitions.Add(classDefinition);
			}

			return Definitions.Count;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach(var classDefinition in Definitions)
			{
				foreach(var fieldDefinition in classDefinition.Fields)
				{
					fieldDefinition.TranslatedName = VulkanSpec.GetTranslatedName(fieldDefinition.SpecName);
					fieldDefinition.AddModifier(SyntaxKindDto.PublicKeyword);
					fieldDefinition.AddModifier(SyntaxKindDto.ConstKeyword);
				}

				count++;
			}

			return count;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var classDefintion in Definitions)
			{
				var output = new OutputDefinition() { FileName = classDefintion.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.OutputDirectory = "Constants";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				//foreach (var commentLine in classDefintion.Comments)
				//{
				//	output.CommentLines.Add(commentLine);
				//}

				output.AddStandardUsingDirective("System");

				(Generator as CSharpGenerator).GenerateClass(output, classDefintion);
				count++;
			}

			return count;
		}
	}
}
