using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan
{
	public class VulkanSpec : SpawnSpec<registry>
	{
		public VulkanSpec(XmlFileLoader<registry> xmlFileLoader)
			: base(xmlFileLoader)
		{
		}
	}
}
