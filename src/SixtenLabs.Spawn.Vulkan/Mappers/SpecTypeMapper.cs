using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class SpecTypeMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryType, SpecTypeDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(src => MapName(src)))
				.ForMember(dest => dest.TranslatedName, opt => opt.MapFrom(src => MapTranslatedName(src)));

			CreateMap<registryEnumsEnum, SpecTypeDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(src => MapName(src)))
				.ForMember(dest => dest.TranslatedName, opt => opt.MapFrom(src => MapTranslatedName(src)));
		}

		private string MapName(registryEnumsEnum ree)
		{
			string name = null;

			name = ree.name;

			return name;
		}

		private string MapTranslatedName(registryEnumsEnum ree)
		{
			string name = null;

			name = ree.name.TranslateVulkanName();

			return name;
		}

		private string MapName(registryType rt)
		{
			string name = null;

			if (rt.category == "basetype" || rt.category == "bitmask" || rt.category == "handle")
			{
				name = rt.Items[1] as string;
			}
			else if (rt.category == "enum" || rt.category == "struct" || rt.category == "union" || Requires.Contains(rt.requires) || (rt.category == "define" && !string.IsNullOrEmpty(rt.name)))
			{
				name = rt.name;
			}
			else if (rt.category == "funcpointer")
			{
				name = rt.Items[0] as string;
			}
			else if (rt.category == "include" || rt.category == "define")
			{
				name = string.IsNullOrEmpty(rt.name) ? rt.Items[0] as string : rt.name;
			}

			return name;
		}

		private string MapTranslatedName(registryType rt)
		{
			string name = null;

			if (Requires.Contains(rt.requires))
			{
				name = CToCSharpTypes[rt.name];
			}
			else if (rt.category == "basetype")
			{
				name = CToCSharpTypes[rt.Items[0] as string];
			}
			else if (rt.category == "bitmask" && !string.IsNullOrEmpty(rt.requires))
			{
				// Real Enum
				name = (rt.Items[1] as string).TranslateVulkanName();
			}
			else if (rt.category == "bitmask" && string.IsNullOrEmpty(rt.requires))
			{
				// Not real enum.
				name = CToCSharpTypes[rt.Items[0] as string];
			}
			else if (rt.category == "handle")
			{
				name = (rt.Items[1] as string).TranslateVulkanName();
			}
			else if (rt.category == "enum")
			{
				name = rt.name.TranslateVulkanName();
			}
			else if (rt.category == "funcpointer")
			{
				name = (rt.Items[0] as string).TranslateVulkanName();
			}
			else if (rt.category == "struct")
			{
				name = rt.name.TranslateVulkanName();
			}
			else if (rt.category == "union")
			{
				name = rt.name.TranslateVulkanName();
			}
			else if (rt.category == "include" || rt.category == "define")
			{
				name = string.IsNullOrEmpty(rt.name) ? rt.Items[0] as string : rt.name;
			}
			else
			{
				name = "";
			}

			return name;
		}

		private IList<string> Requires { get; } = new List<string>()
		{
			"X11/Xlib.h",
			"android/native_window.h",
			"mir_toolkit/client_types.h",
			"wayland-client.h",
			"windows.h",
			"xcb/xcb.h",
			"vk_platform"
		};

		/// <summary>
		/// Translate the Vulkan types to C# types.
		/// </summary>
		private IDictionary<string, string> CToCSharpTypes { get; } = new Dictionary<string, string>()
		{
			{ "void", "IntPtr" },
			{ "char", "char" }, // Should this be string?
			{ "float", "float" },
			{ "uint8_t", "byte" },
			{ "uint32_t", "uint" },
			{ "uint64_t", "ulong" },
			{ "int32_t", "int" },
			{ "size_t", "UIntPtr" },
			{ "VkSampleMask", "uint" },
			{ "VkBool32", "uint" },
			{ "VkFlags", "uint" },
			{ "VkDeviceSize", "ulong" },
			{ "Display", "IntPtr" },
			{ "VisualID", "IntPtr" },
			{ "Window", "IntPtr" },
			{ "ANativeWindow", "IntPtr" },
			{ "MirConnection", "IntPtr" },
			{ "MirSurface", "IntPtr" },
			{ "wl_display", "IntPtr" },
			{ "wl_surface", "IntPtr" },
			{ "HINSTANCE", "IntPtr" },
			{ "HWND", "IntPtr" },
			{ "xcb_connection_t", "IntPtr" },
			{ "xcb_visualid_t", "IntPtr" },
			{ "xcb_window_t", "IntPtr" },
		};
	}
}
