using SixtenLabs.Spawn.Utility;
using System.Collections.Generic;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	/// <summary>
	/// Basic C Types. This needs to go first as other mappings are dependent upon 
	/// these types being translated.
	/// </summary>
	public class VulkanTypeMapper : BaseTypeMapper<registry>
	{
		public VulkanTypeMapper(ISpawnSpec<registry> spawnSpec)
			: base(spawnSpec)
		{
		}

		private void MapVkPlatformTypes()
		{
			var platformTypes = SpawnSpec.SpecTree.types.Where(x => x.requires == "vk_platform");

			foreach (var platformType in platformTypes)
			{
				SpawnSpec.AddSpecType(platformType.name, CToCSharpTypes[platformType.name]);
			}
		}

		/// <summary>
		/// TODO: do we need to handle include and define categories?
		/// </summary>
		private void MapBaseTypes()
		{
			var baseTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "basetype");

			foreach (var baseType in baseTypes)
			{
				var specName = (string)baseType.Items[1];
				SpawnSpec.AddSpecType(specName, CToCSharpTypes[specName]);
			}
		}

		private void MapBitmaskTypes()
		{
			var bitmaskTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "bitmask");

			foreach (var bitmaskType in bitmaskTypes)
			{
				if (string.IsNullOrEmpty(bitmaskType.requires))
				{
					// We only need to add to typemap, it is not going to be full blown enum (yet)
					var specName = (string)bitmaskType.Items[1];
					var enumBaseType = (string)bitmaskType.Items[0];
					var specType = SpawnSpec.FindTypeDefinition(enumBaseType);
					SpawnSpec.AddSpecType(specName, specType.TranslatedName);
				}
				else
				{
					// Both the name and the requires name are used in the spec. So we add both translated to same thing.
					var specName = (string)bitmaskType.Items[1];
					var translatedName = specName.TranslateVulkanName();
					SpawnSpec.AddSpecType(specName, translatedName);

					var requiredName = bitmaskType.requires;
					var requiredTranslatedName = requiredName.TranslateVulkanName();
					SpawnSpec.AddSpecType(requiredName, requiredTranslatedName);
				}
			}
		}

		/// <summary>
		/// Types which can be void pointers or class pointers, selected at compile time
		/// </summary>
		private void MapHandleTypes()
		{
			var handleTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "handle");

			foreach (var handleType in handleTypes)
			{
				var specName = (string)handleType.Items[1];
				var translatedName = specName.TranslateVulkanName();
				SpawnSpec.AddSpecType(specName, translatedName);
			}
		}

		/// <summary>
		/// We already mapped the flags enums so dont add them again.
		/// </summary>
		private void MapEnumTypes()
		{
			var enumTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "enum");

			foreach (var enumType in enumTypes)
			{
				if (!enumType.name.EndsWith("FlagBits"))
				{
					var specName = enumType.name;
					var translatedName = specName.TranslateVulkanName();
					SpawnSpec.AddSpecType(specName, translatedName);
				}
			}
		}

		private void MapFunctionPointers()
		{
			var functionPointerTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "funcpointer");

			foreach (var functionPointerType in functionPointerTypes)
			{
				var specName = (string)functionPointerType.Items[0];
				var translatedName = specName.TranslateVulkanName();
				SpawnSpec.AddSpecType(specName, translatedName);
			}
		}

		private void MapStructs()
		{
			var structTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "struct");

			foreach (var structType in structTypes)
			{
				var specName = structType.name;
				var translatedName = specName.TranslateVulkanName();
				SpawnSpec.AddSpecType(specName, translatedName);
			}
		}

		private void MapUnions()
		{
			var unionTypes = SpawnSpec.SpecTree.types.Where(x => x.category == "union");

			foreach (var unionType in unionTypes)
			{
				var specName = unionType.name;
				var translatedName = specName.TranslateVulkanName();
				SpawnSpec.AddSpecType(specName, translatedName);
			}
		}

		/// <summary>
		/// Currently mapping these UI library names to IntPtr
		/// </summary>
		private void MapPlatformCrap()
		{
			var platformCrapTypes = SpawnSpec.SpecTree.types.Where(x => x.requires == "X11/Xlib.h" ||
			x.requires == "android/native_window.h" || 
			x.requires == "mir_toolkit/client_types.h" || 
			x.requires == "wayland-client.h" ||
			x.requires == "windows.h" ||
			x.requires == "xcb/xcb.h");

			foreach (var platformCrapType in platformCrapTypes)
			{
				SpawnSpec.AddSpecType(platformCrapType.name, CToCSharpTypes[platformCrapType.name]);
			}
		}

		/// <summary>
		/// These are mainly primitives like void, uint32_t, size_t, etc. 
		/// They are treated specially by the pipeline.
		/// </summary>
		public override int MapTypes()
		{
			var startingCount = SpawnSpec.SpecTypeCount;

			MapPlatformCrap();
			MapVkPlatformTypes();
			MapBaseTypes();
			MapBitmaskTypes();
			MapHandleTypes();
			MapEnumTypes();
			MapFunctionPointers();
			MapStructs();
			MapUnions();

			return SpawnSpec.SpecTypeCount - startingCount;
		}

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
