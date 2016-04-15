using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	//public class UnionCreator : BaseCreator<UnionDefinition>
	//{
	//	public UnionCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
	//		: base(generator, spawnSpec, 2)
	//	{
	//	}

	//	private UnionDefinition ReadUnion(registryType structElement)
	//	{
	//		var structDefinition = new UnionDefinition();

	//		var specName = structElement.name;
	//		var name = specName.TranslateVulkanName();

	//		structDefinition.SpecName = specName;
	//		structDefinition.TranslatedName = name;

	//		var structMembers = structElement.Items;

	//		foreach (var structMember in structMembers)
	//		{
	//			//var memberSpecName = structMember.Element("name").Value;
	//			//var memberName = specName.TranslateVulkanName();
	//			//var specType = structMember.Element("type").Value;

	//			//structDefinition.AddField(specName, name, specType);
	//		}

	//		return structDefinition;
	//	}

	//	public override int MapTypes()
	//	{
	//		//var structTypes = VulkanSpec.SpecTree.types.Where(x => x.category != null && x.category == "union");

	//		//var unions = structTypes.Select(ReadUnion);

	//		//foreach (var unionDefinition in unions)
	//		//{
	//		//	Definitions.Add(unionDefinition);
	//		//	VulkanSpec.AllTypes.Add(unionDefinition.SpecName, unionDefinition.Name);
	//		//}

	//		return Definitions.Count;
	//	}

	//	public override int Rewrite()
	//	{
	//		return 0;
	//	}

	//	public override int Build()
	//	{
	//		return 0;
	//	}

	//	public override int Create()
	//	{
	//		return 0;
	//	}
	//}
}
