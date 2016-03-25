using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan
{
	/// <summary>
	/// The code generation is controlled from this settings class.
	/// </summary>
	public class VulkanSettings : GeneratorSettings
	{
		public VulkanSettings()
			: base("Spawn.sln", "SixtenLabs.Spawn.Vulkan.Target", "vk.xml", "https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/1.0/src/spec/vk.xml", "1.0")
		{
		}
	}
}
