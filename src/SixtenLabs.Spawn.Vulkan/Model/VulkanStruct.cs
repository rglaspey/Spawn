using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan.Model
{
	public class VulkanStruct : VulkanType
	{
		public VulkanStruct()
			: base(VulkanTypeCategory.Struct)
		{
			Members = new VulkanMember[0];
			Validity = new string[0];
		}

		public VulkanMember[] Members { get; set; }

		public bool ReturnedOnly { get; set; }
		public string[] Validity { get; set; }

		public string SpecName { get; set; }
	}
}
