using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	//public class ImportCreator : BaseCreator
	//{
	//	public ImportCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
	//		: base(generator, vulkanSpec, 1, "Import", "Import")
	//	{
	//	}

	//	private VulkanStruct CreateImportStruct(string name)
	//	{
	//		var vkStruct = new VulkanStruct();
	//		vkStruct.Name = vkStruct.SpecName = name;
	//		return vkStruct;
	//	}

	//	public override void MapTypes()
	//	{
	//		// BaseType
	//		VulkanSpec.AllTypes.Add("VkSampleMask", CreateImportStruct("VkSampleMask"));
	//		VulkanSpec.AllTypes.Add("VkBool32", CreateImportStruct("VkBool32"));
	//		VulkanSpec.AllTypes.Add("VkDeviceSize", CreateImportStruct("VkDeviceSize"));

	//		// Imports
	//		VulkanSpec.AllTypes.Add("Display", CreateImportStruct("VkDeviceSize"));
	//		VulkanSpec.AllTypes.Add("VisualID", CreateImportStruct("VisualID"));
	//		VulkanSpec.AllTypes.Add("Window", CreateImportStruct("Window"));
	//		VulkanSpec.AllTypes.Add("ANativeWindow", CreateImportStruct("ANativeWindow"));
	//		VulkanSpec.AllTypes.Add("MirConnection", CreateImportStruct("MirConnection"));

	//		VulkanSpec.AllTypes.Add("MirSurface", CreateImportStruct("MirSurface"));
	//		VulkanSpec.AllTypes.Add("wl_display", CreateImportStruct("wl_display"));
	//		VulkanSpec.AllTypes.Add("wl_surface", CreateImportStruct("wl_surface"));
	//		VulkanSpec.AllTypes.Add("HINSTANCE", CreateImportStruct("HINSTANCE"));
	//		VulkanSpec.AllTypes.Add("HWND", CreateImportStruct("HWND"));

	//		VulkanSpec.AllTypes.Add("xcb_connection_t", CreateImportStruct("xcb_connection_t"));
	//		VulkanSpec.AllTypes.Add("xcb_visualid_t", CreateImportStruct("xcb_visualid_t"));
	//		VulkanSpec.AllTypes.Add("xcb_window_t", CreateImportStruct("xcb_window_t"));
	//	}

	//	public override void Rewrite()
	//	{
	//	}

	//	public override void Build()
	//	{

	//	}

	//	public override void Create()
	//	{
	//	}
	//}
}
