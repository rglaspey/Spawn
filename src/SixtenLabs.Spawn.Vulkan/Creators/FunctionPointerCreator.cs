using AutoMapper;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	//public class FunctionPointerCreator : BaseCreator<registry, DelegateDefinition>
	//{
	//	public FunctionPointerCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
	//		: base(generator, spawnSpec, 9)
	//	{
	//	}

	//	private void ProcessParameters(DelegateDefinition delegateDefinition, registryType registryType)
	//	{
	//		foreach(var item in registryType.Items)
	//		{

	//		}
	//	}

	//	public override int Rewrite()
	//	{
	//		return 0;
	//	}

	//	public override int Build(IMapper mapper)
	//	{
	//		var registryFunctionPointers = VulkanSpec.SpecTree.types.Where(x => x.category == "funcpointer");

	//		foreach (var registryFunctionPointer in registryFunctionPointers)
	//		{
	//			var delegateDefinition = new DelegateDefinition();

	//			var specName = registryFunctionPointer.Items[0] as string;
	//			var translatedName = VulkanSpec.FindTypeDefinition(specName).TranslatedName;

	//			//delegateDefinition.AddModifier(Modifiers.Public, 0);
	//			//delegateDefinition.AddModifier(Modifiers.Partial, 1);
	//			delegateDefinition.SpecName = specName;
	//			delegateDefinition.TranslatedName = translatedName;

	//			var specType = registryFunctionPointer.Items[1] as string;
	//			var translatedType = VulkanSpec.FindTypeDefinition(specType).TranslatedName;

	//			ProcessParameters(delegateDefinition, registryFunctionPointer);

	//			Definitions.Add(delegateDefinition);
	//		}

	//		return Definitions.Count;
	//	}

	//	public override int Create()
	//	{
	//		int count = 0;

	//		foreach (var classDefintion in Definitions)
	//		{
	//			var output = new OutputDefinition<DelegateDefinition>() { FileName = classDefintion.TranslatedName };
	//			output.TargetSolution = TargetSolution;
	//			output.AddNamespace(TargetNamespace);
	//			output.TemplateName = "DelegateTemplate";
	//			output.OutputDirectory = "Delegates";

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
