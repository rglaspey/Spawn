using SixtenLabs.Spawn.Utility;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Globalization;
using System.Text;

namespace SixtenLabs.Spawn.Vulkan
{
	public class VulkanRules : ICreatorRules
	{
		public VulkanRules(XmlFileLoader xmlFileLoader)
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
	}
}
