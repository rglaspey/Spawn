using SixtenLabs.Spawn.Utility;
using System;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class StructCreator : BaseCreator
	{
		public StructCreator(ISpawn spawn, ICodeGenerator generator, ICreatorRules rules)
			: base(spawn, generator, rules, "Struct", "Struct")
		{
		}

		public string TransformStructName(string value)
		{
			var final = value.Replace("Vk", string.Empty);

			return final;
		}

		public override void MapTypes()
		{
			var enumTypes = Rules.GetTypes("struct");

			foreach (var enumType in enumTypes)
			{
				var name = enumType.Attribute("name").Value;
				var transformedName = TransformStructName(name);

				Rules.MapType(name, transformedName);
			}
		}

		public override void Build()
		{
			
		}

		public override void Create()
		{
			//var structs = registry.types.Where(x => x.category == "struct");

			//foreach (var s in structs)
			//{
			//	var structName = Rules.TransformStructName(s.name);

			//	var output = new OutputDefinition($"{structName}.cs");
			//	output.AddNamespace(TargetNamespace);

			//	var definition = new StructDefinition(structName);
			//	definition.AddModifier(SyntaxKindX.PublicKeyword);

			//	foreach(var item in s.Items)
			//	{
			//		if(item is registryTypeMember)
			//		{
			//			var registryTypeMember = item as registryTypeMember;

			//			var name = registryTypeMember.name;
			//			var type = registryTypeMember.type;

			//			definition.AddField(name, Rules.TypeMaps[type]);
			//		}
			//		else if(item is registryTypeValidity)
			//		{

			//		}
			//		else
			//		{
			//			throw new InvalidOperationException("Not handling a struct item yet.");
			//		}

			//	}

			//	var contents = Generator.GenerateStruct(output, definition);
			//	Spawn.AddDocumentToProject(TargetSolution, definition.Name, contents, new string[] { "Structs" });

			//	NumberCreated++;
		}
	}
}