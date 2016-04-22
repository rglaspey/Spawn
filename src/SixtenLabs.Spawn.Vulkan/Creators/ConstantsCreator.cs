using AutoMapper;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	public class ConstantsCreator : BaseCreator<registry, ClassDefinition>
	{
		public ConstantsCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 9)
		{
		}

		private void ProcessValue(FieldDefinition constantDefinition)
		{
			if (!string.IsNullOrEmpty(constantDefinition.SpecValue))
			{
				if (constantDefinition.SpecValue.Contains("f"))
				{
					constantDefinition.SpecType = "float";
					constantDefinition.TranslatedType = "float";
					constantDefinition.TranslatedValue = constantDefinition.SpecValue;
				}
				else if (constantDefinition.SpecValue.Contains("(~0U)"))
				{
					constantDefinition.SpecType = "uint";
					constantDefinition.TranslatedType = "uint";
					constantDefinition.TranslatedValue = "uint.MaxValue";
				}
				else if (constantDefinition.SpecValue.Contains("(~0ULL)"))
				{
					constantDefinition.SpecType = "ulong";
					constantDefinition.TranslatedType = "ulong";
					constantDefinition.TranslatedValue = "ulong.MaxValue";
				}
				else
				{
					constantDefinition.SpecType = "uint";
					constantDefinition.TranslatedType = "uint";
					constantDefinition.TranslatedValue = constantDefinition.SpecValue;
				}
			}
		}

		public override int Build(IMapper mapper)
		{
			var registryConstants = VulkanSpec.SpecTree.enums.Where(x => x.name == "API Constants");

			foreach (var registryConstant in registryConstants)
			{
				var classDefinition = mapper.Map<registryEnums, ClassDefinition>(registryConstant);

				classDefinition.AddModifier(Modifiers.Public, 0);
				classDefinition.AddModifier(Modifiers.Const, 1);
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
					fieldDefinition.Modifiers.Add(new ModifierDefinition() { Modifier = Modifiers.Public, Order = 0 });
					fieldDefinition.Modifiers.Add(new ModifierDefinition() { Modifier = Modifiers.Const, Order = 1 });
					ProcessValue(fieldDefinition);
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
				var output = new OutputDefinition<ClassDefinition>() { FileName = classDefintion.TranslatedName };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.TemplateName = "ClassTemplate";
				output.OutputDirectory = "Constants";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				foreach (var commentLine in classDefintion.Comments)
				{
					output.CommentLines.Add(commentLine);
				}

				output.TypeDefinitions.Add(classDefintion);
				output.AddStandardUsingDirective("System");

				Generator.GenerateCodeFile(output);
				count++;
			}

			return count;
		}
	}
}
