namespace SixtenLabs.Spawn.Vulkan.Model
{
	public class VulkanHandle : VulkanType
	{
		public VulkanHandle()
			: base(VulkanTypeCategory.Handle)
		{
		}

		public string HandleType { get; set; }

		public string Parent { get; set; }
	}
}
