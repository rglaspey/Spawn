using SimpleInjector;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.OpenGL.Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			Bootstrap();

			GenerateOpenGLBindings();

			Console.ReadLine();
		}

		private static void Bootstrap()
		{
			SimpleContainer = new Container();

			SimpleContainer.RegisterSingleton<ISpawnService, SpawnService>();
			SimpleContainer.RegisterSingleton<IGeneratorSettings, GlSettings>();
			//SimpleContainer.RegisterSingleton<XmlFileLoader>();

			SimpleContainer.Verify();
		}

		private static void GenerateOpenGLBindings()
		{
			var spawn = SimpleContainer.GetInstance<ISpawnService>();

			spawn.Initialize("../../../../../Spawn/Spawn.sln");

			var settings = new GlSettings();

			// Load opengl registry
			//var loader = new XmlFileLoader(settings);
			//var registry = loader.LoadRegistry();

			//CreateEnums(registry, spawn);
		}

		private static void CreateEnums(registry registry, ISpawnService spawn)
		{
			//var generator = new CSharpGenerator();

			//foreach(var e in registry.groups)
			//{
			//	var output = new OutputDefinition() { Name = $"{e.name}.cs" };
			//	//output.AddStandardUsingDirective("System");
			//	//output.AddStandardUsingDirective("System.Linq");
			//	output.AddNamespace("SixtenLabs.Spawn.OpenGL.Target");

			//	var definition = new EnumDefinition(e.name);
			//	definition.AddModifier(SyntaxKindX.PublicKeyword);
				
			//	if (e.@enum != null)
			//	{
			//		foreach (var enumValue in e.@enum)
			//		{
			//			var transformedEnumName = TransformEnumName(enumValue.name);
						
			//			definition.AddEnumMember(transformedEnumName, "0");
			//		}
			//	}

			//	var contents = generator.GenerateEnum(output, definition);

			//	Console.WriteLine($"Creating {e.name}");
			//	spawn.AddDocumentToProject("SixtenLabs.Spawn.OpenGL.Target", definition.Name, contents, new string[] { "Enums" });
			//	Console.WriteLine($"Done Creating {e.name}");
			//}
		}

		private static string TransformEnumName(string value)
		{
			string x = value.Replace("GL_", string.Empty);

			return x;
		}

		private static Container SimpleContainer { get; set; }
	}
}
