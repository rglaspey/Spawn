using AutoMapper;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	//public class HandleCreator : BaseCreator<registry, ClassDefinition>
	//{
	//	public HandleCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
	//		: base(generator, spawnSpec, 20)
	//	{
	//	}

	//	public override int Rewrite()
	//	{
	//		return 0;
	//	}

	//	public override int Build(IMapper mapper)
	//	{
	//		var registryHandles = VulkanSpec.SpecTree.types.Where(x => x.category == "handle");

	//		foreach(var registryHandle in registryHandles)
	//		{
	//			var classDefinition = new ClassDefinition();

	//			var specName = registryHandle.Items[1] as string;
	//			var translatedName = VulkanSpec.FindTypeDefinition(specName).TranslatedName;

	//			classDefinition.SpecName = specName;
	//			classDefinition.TranslatedName = translatedName;

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
	//			output.OutputDirectory = "Handles";

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
