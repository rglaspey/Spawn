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

		void MapType(string name, string transformedName);

		IEnumerable<XElement> GetTypes(string type);

		VulkanType GetOrAddType(string name);

		string TransformedName(string key);

		XElement SpecTree { get; }

		IDictionary<string, VulkanType> AllTypes { get; }

		IEnumerable<VulkanStruct> Structs { get; }

		IEnumerable<VulkanHandle> Handles { get; }

		IEnumerable<VulkanEnum> Enums { get; }

		VulkanCommand[] Commands { get; set; }

		VulkanFeature[] Features { get; set; }
	}
}
