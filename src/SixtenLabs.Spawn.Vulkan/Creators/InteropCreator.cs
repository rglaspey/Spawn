using SixtenLabs.Spawn.Utility;
using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;

namespace SixtenLabs.Spawn.Vulkan.Creators
{
	public class InteropCreator : BaseCreator<registry, MethodDefinition>
	{
		public InteropCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 30)
		{
		}

		public override int Build(IMapper mapper)
		{
			var registryCommands = VulkanSpec.SpecTree.commands;

			foreach (var registryEnum in registryCommands)
			{
				var commandDefinition = mapper.Map<registryCommand, MethodDefinition>(registryEnum);
				Definitions.Add(commandDefinition);
			}

			return Definitions.Count;
		}

		public override int Rewrite()
		{
			int count = 0;

			foreach (var methodDefinition in Definitions)
			{
				methodDefinition.TranslatedName = VulkanSpec.GetTranslatedName(methodDefinition.SpecName);
				methodDefinition.AddModifier(SyntaxKindDto.InternalKeyword);
				methodDefinition.AddModifier(SyntaxKindDto.StaticKeyword);
				methodDefinition.AddModifier(SyntaxKindDto.UnsafeKeyword);
				methodDefinition.AddModifier(SyntaxKindDto.ExternKeyword);

				count++;
			}

			return count;
		}

		public override int Create()
		{
			int count = 0;

			//var output = new OutputDefinition() { FileName = "NativeMethods" };
			//output.TargetSolution = TargetSolution;
			//output.AddNamespace(TargetNamespace);
			//output.TemplateName = "ClassTemplate";
			//output.OutputDirectory = "Interop";

			//foreach (var commentLine in GeneratedComments)
			//{
			//	output.CommentLines.Add(commentLine);
			//}

			//var classDefinition = new ClassDefinition() { SpecName = "NativeMethods" };
			//classDefinition.TranslatedName = "NativeMethods";
			//classDefinition.AddModifier(SyntaxKindDto.InternalKeyword);
			//classDefinition.AddModifier(SyntaxKindDto.StaticKeyword);
			//classDefinition.Fields.Add(new FieldDefinition() { TranslatedName = "VulkanLibrary", TranslatedType = "string", TranslatedValue = "vulkan" });

			////classDefinition.Methods.AddRange(Definitions);

			//output.AddStandardUsingDirective("System");
			//output.AddStandardUsingDirective("System.Runtime.InteropServices");

			//(Generator as CSharpGenerator).GenerateClass(output, classDefinition);
			//count++;

			return count;
		}
	}
}
