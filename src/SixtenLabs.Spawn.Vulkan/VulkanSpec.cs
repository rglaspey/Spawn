﻿using SixtenLabs.Spawn.Utility;
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

		public TypeDefinition GetOrAddType(string name)
		{
			if (AllTypes.ContainsKey(name))
			{
				return AllTypes[name];
			}

			// Could be one of the poorly-named enums
			var enumName = name.GetEnumName();

			if (AllTypes.ContainsKey(enumName))
			{
				return AllTypes[enumName];
			}

			var newType = new TypeDefinition();
			newType.Name = name;

			AllTypes.Add(name, newType);

			return newType;
		}

		private XmlFileLoader FileLoader { get; set; }

		public XElement SpecTree
		{
			get
			{
				return FileLoader.Registry;
			}
		}

		public IDictionary<string, TypeDefinition> AllTypes { get; } = new Dictionary<string, TypeDefinition>();

		public IEnumerable<StructDefinition> Structs
		{
			get
			{
				return AllTypes.Values.Where(x => x is StructDefinition).Cast<StructDefinition>().ToArray();
			}
		}

		public IEnumerable<HandleDefinition> Handles
		{
			get
			{
				return AllTypes.Values.Where(x => x is HandleDefinition).Cast<HandleDefinition>().ToArray();
			}
		}

		public IEnumerable<EnumDefinition> Enums
		{
			get
			{
				return AllTypes.Values.Where(x => x is EnumDefinition).Cast<EnumDefinition>().ToArray();
			}
		}

		public VulkanCommand[] Commands { get; set; }

		public VulkanFeature[] Features { get; set; }
	}
}