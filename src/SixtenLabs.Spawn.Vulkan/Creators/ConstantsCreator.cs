using AutoMapper;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	//public class ConstantsCreator : BaseCreator<registry, ClassDefinition>
	//{
	//	public ConstantsCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
	//		: base(generator, spawnSpec, 9)
	//	{
	//	}

	//	public override int Rewrite()
	//	{
	//		return 0;
	//	}

	//	private void ProcessValue(ConstantDefinition constantDefinition, string value)
	//	{
	//		if(!string.IsNullOrEmpty(value))
	//		{
	//			if(value.Contains("f"))
	//			{
	//				constantDefinition.SpecType = "float";
	//				constantDefinition.TranslatedType = "float";
	//				constantDefinition.Value = value;
	//			}
	//			else if (value.Contains("(~0U)"))
	//			{
	//				constantDefinition.SpecType = "uint";
	//				constantDefinition.TranslatedType = "uint";
	//				constantDefinition.Value = "uint.MaxValue";
	//			}
	//			else if (value.Contains("(~0ULL)"))
	//			{
	//				constantDefinition.SpecType = "ulong";
	//				constantDefinition.TranslatedType = "ulong";
	//				constantDefinition.Value = "ulong.MaxValue";
	//			}
	//			else
	//			{
	//				constantDefinition.SpecType = "uint";
	//				constantDefinition.TranslatedType = "uint";
	//				constantDefinition.Value = value;
	//			}
	//		}
	//	}

	//	public override int Build(IMapper mapper)
	//	{
	//		var registryConstants = VulkanSpec.SpecTree.enums.Where(x => x.name == "API Constants");

	//		foreach (var registryConstant in registryConstants)
	//		{
	//			var classDefinition = new ClassDefinition();

	//			classDefinition.AddModifier(Modifiers.Public, 0);
	//			classDefinition.AddModifier(Modifiers.Const, 1);
	//			classDefinition.SpecName = registryConstant.name;
	//			classDefinition.TranslatedName = "ApiConstants";

	//			foreach(var constant in registryConstant.@enum.AsEnumerable())
	//			{
	//				var constantDefinition = new ConstantDefinition();

	//				constantDefinition.Modifier = new ModifierDefinition() { Modifier = Modifiers.Public };
	//				constantDefinition.SpecName = constant.name;
	//				constantDefinition.TranslatedName = constant.name.TranslateVulkanName();

	//				ProcessValue(constantDefinition, constant.value);

	//				VulkanSpec.AddSpecType(constantDefinition.SpecName, constantDefinition.TranslatedName);

	//				classDefinition.Constants.Add(constantDefinition);
	//			}


	//			Definitions.Add(classDefinition);
	//		}

	//		return Definitions.Count;
	//	}

	//	public override int Create()
	//	{
	//		int count = 0;

	//		foreach (var classDefintion in Definitions)
	//		{
	//			var output = new OutputDefinition<ClassDefinition>() { FileName = classDefintion.TranslatedName };
	//			output.TargetSolution = TargetSolution;
	//			output.AddNamespace(TargetNamespace);
	//			output.TemplateName = "ClassTemplate";
	//			output.OutputDirectory = "Constants";

	//			foreach (var commentLine in GeneratedComments)
	//			{
	//				output.CommentLines.Add(commentLine);
	//			}

	//			foreach (var commentLine in classDefintion.Comments)
	//			{
	//				output.CommentLines.Add(commentLine);
	//			}

	//			output.TypeDefinitions.Add(classDefintion);
	//			output.AddStandardUsingDirective("System");

	//			Generator.GenerateCodeFile(output);
	//			count++;
	//		}

	//		return count;
	//	}
	//}
}
