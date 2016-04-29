using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class UnionCreator : BaseCreator<registry, StructDefinition>
	{
		public UnionCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 40)
		{
			//Off = true;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach (var structDefinition in Definitions)
			{
				structDefinition.TranslatedName = VulkanSpec.GetTranslatedName(structDefinition.SpecName);

				if (!string.IsNullOrEmpty(structDefinition.SpecReturnType))
				{
					structDefinition.TranslatedReturnType = VulkanSpec.GetTranslatedName(structDefinition.SpecReturnType);
				}

				foreach (var fieldDefinition in structDefinition.Fields)
				{
					if (fieldDefinition.SpecName.Contains("["))
					{
						fieldDefinition.TranslatedName = fieldDefinition.SpecName.Substring(0, fieldDefinition.SpecName.IndexOf("["));
						fieldDefinition.TranslatedReturnType = $"{VulkanSpec.GetTranslatedName(fieldDefinition.SpecReturnType)}[]";
					}
					else
					{
						fieldDefinition.TranslatedReturnType = VulkanSpec.GetTranslatedName(fieldDefinition.SpecReturnType);
					}

					fieldDefinition.AddModifier(SyntaxKindDto.PublicKeyword);
				}

				count++;
			}

			return count;
		}

		public override int Build(IMapper mapper)
		{
			var registryStructs = VulkanSpec.SpecTree.types.Where(x => x.category == "union");

			foreach (var registryEnum in registryStructs)
			{
				var structDefinition = mapper.Map<registryType, StructDefinition>(registryEnum);
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
				output.OutputDirectory = "Unions";
				output.AddStandardUsingDirective("System");

				structDefinition.AddModifier(SyntaxKindDto.PublicKeyword);

				//foreach (var commentLine in GeneratedComments)
				//{
				//	output.CommentLines.Add(commentLine);
				//}

				(Generator as CSharpGenerator).GenerateStruct(output, structDefinition);
				count++;
			}

			return count;
		}
	}
}
