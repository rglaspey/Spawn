using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	public class UnionCreator : BaseCreator
	{
		public UnionCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
			: base(generator, vulkanSpec, 2, "Union", "Union")
		{
		}

		private VulkanStruct CreatePlatformStruct(string name)
		{
			var vkStruct = new VulkanStruct();
			vkStruct.Name = vkStruct.SpecName = name;
			return vkStruct;
		}

		public override void MapTypes()
		{
			// Unions
			VulkanSpec.AllTypes.Add("VkClearValue", CreatePlatformStruct("VkClearValue"));
			VulkanSpec.AllTypes.Add("VkClearColorValue", CreatePlatformStruct("VkClearColorValue"));
		}

		public override void Rewrite()
		{
			
		}

		public override void Build()
		{

		}

		public override void Create()
		{
		}
	}
}
