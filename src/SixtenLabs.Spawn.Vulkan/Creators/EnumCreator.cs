using System.Linq;
using SixtenLabs.Spawn.Utility;
using AutoMapper;

namespace SixtenLabs.Spawn.Vulkan
{
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
			foreach (var enumDefintion in Definitions)
			{
				enumDefintion.TranslatedName = VulkanSpec.GetTranslatedName(enumDefintion.SpecName);

				foreach (var valueDefinition in enumDefintion.Members)
				{
					valueDefinition.TranslatedName = VulkanSpec.GetTranslatedName(valueDefinition.SpecName);
				}
			}

			return 0;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var enumDefinition in Definitions)
			{
				var output = new OutputDefinition<EnumDefinition>() { FileName = enumDefinition.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.TemplateName = "EnumTemplate";
				output.OutputDirectory = "Enums";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				foreach (var commentLine in enumDefinition.Comments)
				{
					output.CommentLines.Add(commentLine);
				}

				output.TypeDefinitions.Add(enumDefinition);

				if (enumDefinition.HasFlags)
				{
					output.AddStandardUsingDirective("System");
				}

				Generator.GenerateCodeFile(output);
				count++;
			}

			return count;
		}
	}
}
