namespace SixtenLabs.Spawn.Vulkan.Model
{
	public class VulkanType
	{
		public VulkanType(VulkanTypeCategory typeCategory = VulkanTypeCategory.None)
		{
			Category = typeCategory;
		}

		public string Name { get; set; }

		public VulkanTypeCategory Category { get; }

		public override string ToString() => Name;
	}
}
