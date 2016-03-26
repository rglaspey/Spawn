using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class StructCreator : BaseCreator
	{
		public StructCreator(ISpawn spawn, ICodeGenerator generator, IVulkanSpec vulkanSpec)
			: base(spawn, generator, vulkanSpec, 40, "Struct", "Struct")
		{
		}

		

		private VulkanMember ReadMember(XElement xmember)
		{
			// note: pretty much identical to <param>

			if (xmember.Name != "member")
				throw new ArgumentException("Not a member", nameof(xmember));

			var xelements = xmember.Elements();
			if (xelements.Count() == 0)
				throw new ArgumentException("Contains no elements", nameof(xmember));

			var vkMember = new VulkanMember();

			foreach (var elm in xelements)
			{
				switch (elm.Name.ToString())
				{
					case "type":
						vkMember.Type = VulkanSpec.GetOrAddType(elm.Value);
						break;
					case "name":
						vkMember.Name = vkMember.SpecName = elm.Value;
						break;
					case "enum": // todo
						break;
					default: throw new NotImplementedException(elm.Name.ToString());
				}
			}

			if (string.IsNullOrEmpty(vkMember.Name) || vkMember.Type == null)
				throw new InvalidOperationException("Member does not have proper `<name>` or `<type>` element");

			// Gah! Why are these not encoded properly!
			var paramStr = xmember.Value;
			vkMember.PointerRank = paramStr.Count(x => x == '*');
			vkMember.IsConst = paramStr.Contains("const");

			// read member attributes
			var xattributes = xmember.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "optional":
							var value = xattrib.Value;
							if (value != "true") throw new NotImplementedException(value);
							vkMember.Optional = value;
							break;
						case "len":
							vkMember.Len = xattrib.Value;
							break;
						/*case "externsync":
						param.ExternSync = attrib.Value == "true";
						break;*/
						case "noautovalidity":
							vkMember.NoAutoValidity = xattrib.Value == "true";
							break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			return vkMember;
		}

		private VulkanStruct ReadStruct(XElement xstruct, VulkanStruct vkStruct)
		{
			if (xstruct.Name != "type")
				throw new ArgumentException("Not a type element", nameof(xstruct));

			var xcategory = xstruct.Attribute("category");
			if (xcategory == null || xcategory.Value != "struct")
				throw new ArgumentException("Invalid category", nameof(xstruct));

			var xattributes = xstruct.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "name":
							vkStruct.Name = vkStruct.SpecName = xattrib.Value;
							break;
						case "returnedonly":
							vkStruct.ReturnedOnly = xattrib.Value == "true";
							break;
						case "category":
							break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			vkStruct.Members = xstruct.Elements("member").Select(ReadMember).ToArray();

			var xvalidity = xstruct.Element("validity");
			if (xvalidity != null)
			{
				vkStruct.Validity = xvalidity.Elements()
						.Select(x => x.Value)
						.ToArray();
			}

			return vkStruct;
		}

		private bool TypeStructFilter(XElement xtype)
		{
			var xcat = xtype.Attribute("category");

			return xcat != null && xcat.Value == "struct";
		}

		private Dictionary<string, XElement> CreateStructureDictionary(IEnumerable<XElement> xstructs)
		{
			var dictionary = new Dictionary<string, XElement>();
			foreach (var xstruct in xstructs)
			{
				if (xstruct.Name != "type")
					throw new ArgumentException("Not a type element", nameof(xstruct));

				var xcategory = xstruct.Attribute("category");
				if (xcategory == null || xcategory.Value != "struct")
					throw new ArgumentException("Invalid category", nameof(xstruct));

				var xnameAttribute = xstruct.Attribute("name");
				if (xnameAttribute == null)
					throw new ArgumentException("Struct does not have a `<name>` attribute!");

				dictionary.Add(xnameAttribute.Value, xstruct);
			}
			return dictionary;
		}

		public override void MapTypes()
		{
			var xTypes = VulkanSpec.SpecTree.Element("types").Elements("type");

			var xstructs = xTypes.Where(TypeStructFilter);

			// Create a map of `struct name` -> `struct xml definition`
			var structDefMap = CreateStructureDictionary(xstructs);

			// Create a VkStruct object for each class before reading the xml definitions,
			// this is so the struct members can refrence other struct types
			var structs = structDefMap.Keys.Select(x => new VulkanStruct { Name = x }).ToArray();

			foreach (var vkStruct in structs)
			{
				VulkanSpec.AllTypes.Add(vkStruct.Name, vkStruct);
			}

			// Read the struct definitions
			for (int x = 0; x < structs.Length; x++)
			{
				ReadStruct(structDefMap[structs[x].Name], structs[x]);
			}
		}

		Dictionary<string, string> structNameOverride = new Dictionary<string, string>
            {
                //{ "void",     "void"    },
                { "char",     "Char"    },
                { "float",    "Single"  },
                { "uint8_t",  "Byte"    },
                { "uint32_t", "UInt32"  },
                { "uint64_t", "UInt64"  },
                { "int32_t",  "Int32"   },
                { "size_t",   "UIntPtr" },
                { "VkBool32", "Boolean" }
            };

		public override void Rewrite()
		{
			foreach(var vkStruct in VulkanSpec.Structs)
			{
				var name = vkStruct.Name;

				if (structNameOverride.ContainsKey(name))
					name = structNameOverride[name];

				if (name.StartsWith("Vk"))
					name = name.Remove(0, 2); // trim `Vk`

				vkStruct.Name = name;

				for (var x = 0; x < vkStruct.Members.Length; x++)
				{
					var member = vkStruct.Members[x];
					var memberName = member.Name;
					if (member.PointerRank != 0)
						memberName = memberName.TrimStart(new[] { 'p' });

					member.Name = memberName;
				}
			}
		}

		public override void Build()
		{
			
		}

		public override void Create()
		{
		}
	}
}