using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Utility
{
	public interface IVulkanSpec
	{
		void ProcessRegistry();

		IEnumerable<XElement> GetTypes(string type);

		XElement SpecTree { get; }

		IDictionary<string, TypeDefinition> AllTypes { get; }

		IEnumerable<StructDefinition> Structs { get; }

		IEnumerable<HandleDefinition> Handles { get; }

		IEnumerable<EnumDefinition> Enums { get; }

		VulkanCommand[] Commands { get; set; }

		VulkanFeature[] Features { get; set; }

		IDictionary<string, string> NameCorrections { get; }
	}
}
