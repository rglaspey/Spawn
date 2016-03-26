using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan.Model
{
	public class VulkanFeature
	{
		public string Api;
		public string Name;
		public string Number;

		public VulkanFeatureRequirement[] Requirements;
	}
}
