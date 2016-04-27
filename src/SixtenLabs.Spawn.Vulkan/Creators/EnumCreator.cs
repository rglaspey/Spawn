using System.Linq;
using SixtenLabs.Spawn.Utility;
using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;

namespace SixtenLabs.Spawn.Vulkan
{
	/// <summary>
	/// TODO : handle extensions. Handle Not real enums (or are they handled from typemapper already, I think so)
	/// </summary>
	public class EnumCreator : BaseCreator<registry, EnumDefinition>
	{
		public EnumCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 10)
		{
		}

		public override int Build(IMapper mapper)
		{
			var registryEnums = VulkanSpec.SpecTree.enums.Where(x => x.name != "API Constants");

			foreach(var registryEnum in registryEnums)
			{
				var enumDefinition = mapper.Map<registryEnums, EnumDefinition>(registryEnum);
				Definitions.Add(enumDefinition);
			}

			return Definitions.Count;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach (var enumDefinition in Definitions)
			{
				enumDefinition.TranslatedName = VulkanSpec.GetTranslatedName(enumDefinition.SpecName);

				foreach (var valueDefinition in enumDefinition.Members)
				{
					valueDefinition.TranslatedName = VulkanSpec.GetTranslatedName(valueDefinition.SpecName);
				}

				count++;
			}

			return count;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var enumDefinition in Definitions)
			{
				var output = new OutputDefinition() { FileName = enumDefinition.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.OutputDirectory = "Enums";

				enumDefinition.AddModifier(SyntaxKindDto.PublicKeyword);

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				//foreach (var commentLine in enumDefinition.Comments)
				//{
				//	output.CommentLines.Add(commentLine);
				//}

				if (enumDefinition.HasFlags)
				{
					output.AddStandardUsingDirective("System");
				}

				(Generator as CSharpGenerator).GenerateEnum(output, enumDefinition);
				count++;
			}

			return count;
		}
	}
}
