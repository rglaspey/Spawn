using SixtenLabs.Spawn.Utility;
using AutoMapper;

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
				methodDefinition.AddModifier(Modifiers.Internal, 0);
				methodDefinition.AddModifier(Modifiers.Static, 1);
				methodDefinition.AddModifier(Modifiers.Unsafe, 2);
				methodDefinition.AddModifier(Modifiers.Extern, 3);

				count++;
			}

			return count;
		}

		public override int Create()
		{
			int count = 0;

			var output = new OutputDefinition<ClassDefinition>() { FileName = "NativeMethods" };
			output.TargetSolution = TargetSolution;
			output.AddNamespace(TargetNamespace);
			output.TemplateName = "ClassTemplate";
			output.OutputDirectory = "Interop";

			foreach (var commentLine in GeneratedComments)
			{
				output.CommentLines.Add(commentLine);
			}

			var classDefinition = new ClassDefinition();
			classDefinition.TranslatedName = "NativeMethods";
			classDefinition.AddModifier(Modifiers.Internal, 0);
			classDefinition.AddModifier(Modifiers.Static, 1);
			classDefinition.Fields.Add(new FieldDefinition() { TranslatedName = "VulkanLibrary", TranslatedType = "string", TranslatedValue = "vulkan" });

			classDefinition.Methods.AddRange(Definitions);

			output.TypeDefinitions.Add(classDefinition);

			output.AddStandardUsingDirective("System");
			output.AddStandardUsingDirective("System.Runtime.InteropServices");

			Generator.GenerateCodeFile(output);
			count++;

			return count;
		}
	}
}
