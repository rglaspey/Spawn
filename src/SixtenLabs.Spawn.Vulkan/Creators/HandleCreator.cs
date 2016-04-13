using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class HandleCreator : BaseCreator<registry, HandleDefinition>
	{
		public HandleCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 20)
		{
		}

		//private HandleDefinition ReadHandle(registryType type)
		//{
		//	var handleDefinition = new HandleDefinition();

		//	handleDefinition.SpecName = (string)type.Items[1];
		//	handleDefinition.Name = handleDefinition.SpecName.TranslateVulkanName();
		//	handleDefinition.HandleType = (string)type.Items[0];

		//	return handleDefinition;
		//}

		public override int Rewrite()
		{
			// Get Type translation?

			//foreach (var handleDefinitions in Definitions)
			//{
			//	//handleDefinitions. = handleDefinitions.SpecName.TranslateVulkanName();
			//}

			return 0;
		}

		public override int Build()
		{
			return 0;
		}

		public override int Create()
		{
			return 0;
		}
	}
}
