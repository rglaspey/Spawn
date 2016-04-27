using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class FunctionPointerCreator : BaseCreator<registry, DelegateDefinition>
	{
		public FunctionPointerCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 9)
		{
			Off = true;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach(var delegateDefinition in Definitions)
			{
				delegateDefinition.TranslatedName = VulkanSpec.GetTranslatedName(delegateDefinition.SpecName);
				delegateDefinition.TranslatedReturnType = VulkanSpec.GetTranslatedName(delegateDefinition.SpecReturnType);

				foreach (var parameterDefinition in delegateDefinition.Parameters)
				{
					parameterDefinition.TranslatedName =parameterDefinition.SpecName;
					parameterDefinition.TranslatedReturnType = VulkanSpec.GetTranslatedName(parameterDefinition.SpecReturnType);
				}

				count++;
			}

			return count;
		}

		public override int Build(IMapper mapper)
		{
			var registryFunctionPointers = VulkanSpec.SpecTree.types.Where(x => x.category == "funcpointer");

			foreach (var registryFunctionPointer in registryFunctionPointers)
			{
				var delegateDefinition = mapper.Map<registryType, DelegateDefinition>(registryFunctionPointer);

				Definitions.Add(delegateDefinition);
			}

			return Definitions.Count;
		}

		public override int Create()
		{
			int count = 0;

			//foreach (var classDefintion in Definitions)
			//{
			//	var output = new OutputDefinition() { FileName = classDefintion.TranslatedName };
			//	output.TargetSolution = TargetSolution;
			//	output.AddNamespace(TargetNamespace);
			//	output.TemplateName = "DelegateTemplate";
			//	output.OutputDirectory = "Delegates";

			//	foreach (var commentLine in GeneratedComments)
			//	{
			//		output.CommentLines.Add(commentLine);
			//	}

			//	foreach (var commentLine in classDefintion.Comments)
			//	{
			//		output.CommentLines.Add(commentLine);
			//	}

			//	output.TypeDefinitions.Add(classDefintion);
			//	output.AddStandardUsingDirective("System");

			//	(Generator as CSharpGenerator).GenerateClass(output, classDefinition);
			//	count++;
			//}

			return count;
		}
	}
}
