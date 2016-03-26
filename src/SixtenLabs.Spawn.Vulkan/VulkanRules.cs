using SixtenLabs.Spawn.Utility;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Globalization;
using System.Text;
using SixtenLabs.Spawn.Vulkan.Model;

namespace SixtenLabs.Spawn.Vulkan
{
	public class VulkanSpec : IVulkanSpec
	{
		public VulkanSpec(XmlFileLoader xmlFileLoader)
		{
			FileLoader = xmlFileLoader;
		}

		public IEnumerable<XElement> GetTypes(string type)
		{
			var elements = FileLoader.Registry.Elements("types").Elements("type").Where(x => (string)x.Attribute("category") == type);

			return elements;
		}

		public void ProcessRegistry()
		{
			FileLoader.LoadRegistry();
		}

		public string TransformedName(string key)
		{
			return TypeMaps[key];
		}

		public void MapType(string name, string transformedName)
		{
			TypeMaps.Add(name, transformedName);
		}

		public VulkanType GetOrAddType(string name)
		{
			if (AllTypes.ContainsKey(name))
				return AllTypes[name];

			// Could be one of the poorly-named enums
			var enumName = name.GetEnumName();
			if (AllTypes.ContainsKey(enumName))
				return AllTypes[enumName];

			var newType = new VulkanType();
			newType.Name = name;

			AllTypes.Add(name, newType);
			return newType;
		}

		public IDictionary<string, string> TypeMaps { get; } = new Dictionary<string, string>()
		{
			//{ "void", "IntPtr" },
			//{ "char", "char" },
			//{ "float", "float" },
			//{ "int32_t", "int" },
			//{ "uint32_t", "uint" },
			//{ "uint64_t", "ulong" },
			//{ "uint8_t", "byte" },
			//{ "size_t", "UIntPtr" },
			//{ "xcb_connection_t", "IntPtr" },
			//{ "xcb_window_t", "IntPtr" },
		};
		
		private XmlFileLoader FileLoader { get; set; }

		public XElement SpecTree
		{
			get
			{
				return FileLoader.Registry;
			}
		}

		public IDictionary<string, VulkanType> AllTypes { get; } = new Dictionary<string, VulkanType>();

		public IEnumerable<VulkanStruct> Structs
		{
			get
			{
				return AllTypes.Values.Where(x => x is VulkanStruct).Cast<VulkanStruct>().ToArray();
			}
		}

		public IEnumerable<VulkanHandle> Handles
		{
			get
			{
				return AllTypes.Values.Where(x => x is VulkanHandle).Cast<VulkanHandle>().ToArray();
			}
		}

		public IEnumerable<VulkanEnum> Enums
		{
			get
			{
				return AllTypes.Values.Where(x => x is VulkanEnum).Cast<VulkanEnum>().ToArray();
			}
		}

		public VulkanCommand[] Commands { get; set; }

		public VulkanFeature[] Features { get; set; }
	}
}
