using System.Linq;
using System.Xml.Linq;
using SixtenLabs.Spawn.Utility;
using System;
using System.Text.RegularExpressions;

namespace SixtenLabs.Spawn.Vulkan
{
	public class EnumCreator : BaseCreator
	{
		public EnumCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
			: base(generator, vulkanSpec, 20, "Enum", "Enum")
		{
		}

		private EnumDefinition ReadEnum(XElement xenums)
		{
			if (xenums.Name != "enums")
			{
				throw new ArgumentException("Not an enum collection", nameof(xenums));
			}

			var vkEnum = new EnumDefinition();

			var xattributes = xenums.Attributes();

			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "name":
							vkEnum.SpecName = xattrib.Value;
							break;
						case "type":
							vkEnum.HasFlags = xattrib.Value == "bitmask";
							break;
						case "expand":
							vkEnum.Expand = xattrib.Value;
							break;
						case "namespace":
							vkEnum.Namespace = xattrib.Value;
							break;
						case "comment":
							vkEnum.Comments.Add(xattrib.Value);
							break;
						default:
							throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			if (string.IsNullOrEmpty(vkEnum.SpecName))
			{
				throw new InvalidOperationException("Enum collection does not have proper `<name>` element");
			}

			// note: there are also `unused` blocks that are not currently used...
			var enumValues = xenums.Elements("enum").Select(ReadEnumValue);
			vkEnum.AddEnumMembers(enumValues);

			return vkEnum;
		}

		private EnumMemberDefinition ReadEnumValue(XElement xenum)
		{
			if (xenum.Name != "enum")
			{
				throw new ArgumentException("Not an enum", nameof(xenum));
			}

			var vkEnum = new EnumMemberDefinition();

			var xattributes = xenum.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "name":
							vkEnum.Name = vkEnum.SpecName = xattrib.Value;
							break;
						case "bitpos":
						case "value":
							vkEnum.Value = xattrib.Value;
							break;
						case "comment":
							vkEnum.Comment = xattrib.Value;
							break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			if (string.IsNullOrEmpty(vkEnum.Name) || string.IsNullOrEmpty(vkEnum.Value))
			{
				throw new InvalidOperationException("Enum collection does not have proper `<name>` or `<value>` or `<bitpos>` element");
			}

			return vkEnum;
		}

		private string FormatFlagValue(int pos)
		{
			return string.Format("0x{0:X}", 1 << pos);
		}
		
		private string EnumExtensionValue(XElement element, int number, ref string csEnumName)
		{
			var offsetAttribute = element.Attribute("offset");

			if (offsetAttribute != null)
			{
				int direction = 1;
				var dirAttr = element.Attribute("dir");

				if (dirAttr != null && dirAttr.Value == "-")
				{
					direction = -1;
				}

				int offset = Int32.Parse(offsetAttribute.Value);

				return (direction * (1000000000 + (number - 1) * 1000 + offset)).ToString();
			}

			var valueAttribute = element.Attribute("value");

			if (valueAttribute != null)
			{
				return valueAttribute.Value;
			}

			var bitposAttribute = element.Attribute("bitpos");

			if (bitposAttribute != null)
			{
				if (csEnumName.EndsWith("FlagBits"))
				{
					csEnumName = csEnumName.Substring(0, csEnumName.Length - 4) + "s";
				}

				return FormatFlagValue(Int32.Parse(bitposAttribute.Value));
			}

			throw new Exception(string.Format("unexpected extension enum value in: {0}", element));
		}

		private void MapEnumExtensions()
		{
			var extensionElements = VulkanSpec.SpecTree.Elements("extensions").Elements("extension").Where(x => x.Attribute("supported").Value != "disabled");

			foreach (var extensionElement in extensionElements)
			{
				var extensions = extensionElement.Element("require").Elements("enum").Where(x => x.Attribute("extends") != null);
				int number = Int32.Parse(extensionElement.Attribute("number").Value);

				foreach (var element in extensions)
				{
					string enumSpecName = element.Attribute("extends").Value;

					if(VulkanSpec.AllTypes.ContainsKey(enumSpecName))
					{
						var enumDefinition = VulkanSpec.Enums.Where(x => x.SpecName == enumSpecName).FirstOrDefault();

						var name = element.Attribute("name").Value;
						var value = EnumExtensionValue(element, number, ref enumSpecName);
						enumDefinition.AddEnumMember(name, value, "Extension Enum Value");
					}
				}
			}
		}

		public override void MapTypes()
		{
			var xTypes = VulkanSpec.SpecTree.Element("types").Elements("type");
						
			var xenums = VulkanSpec.SpecTree.Elements("enums").Where(x => !x.Attribute("name").Value.StartsWith("API C"));
			var enums = xenums.Select(ReadEnum);

			foreach (var vkEnum in enums)
			{
				VulkanSpec.AllTypes.Add(vkEnum.SpecName, vkEnum);
			}

			MapEnumExtensions();
		}

		/// <summary>
		/// trim `Vk`
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private string TranslateEnumName(string specName)
		{
			var name = specName;

			if (specName.StartsWith("Vk"))
			{
				name = specName.Remove(0, 2);
			}

			if(name.Contains("FlagBits"))
			{
				name = name.Replace("FlagBits", string.Empty);
			}

			foreach(var nameCorrection in VulkanSpec.NameCorrections)
			{
				if(name.Contains(nameCorrection.Key))
				{
					name = name.Replace(nameCorrection.Key, nameCorrection.Value);
				}
			}

			return name;
		}

		private string TranslateEnumMemberName(string specName)
		{
			string name = specName;

			if (specName.StartsWith("VK_"))
			{
				name = specName.Substring(3, name.Length - 3);
			}

			name = name.ConvertToTitleCase('_');

			return name;
		}

		public override void Rewrite()
		{
			foreach (var vkEnum in VulkanSpec.Enums)
			{
				vkEnum.Name = TranslateEnumName(vkEnum.SpecName);
				
				foreach (var vkEnumValue in vkEnum.Members)
				{
					vkEnumValue.Name = TranslateEnumMemberName(vkEnumValue.SpecName);
				}

				// After the we've renamed all the enum values, check if there are any that
				// begin with a number (invalid in C#) and fix it.
				if (vkEnum.Members.Any(x => Regex.IsMatch(x.Name, "^[0-9]")))
				{
					foreach (var vkEnumValue in vkEnum.Members)
					{
						var name = vkEnumValue.Name;
						name = vkEnum.Name + name;
						vkEnumValue.Name = name;
					}
				}
			}
		}

		public override void Build()
		{
		}

		public override void Create()
		{
			foreach (var enumDefinition in VulkanSpec.Enums)
			{
				var output = new OutputDefinition<EnumDefinition>() { FileName = enumDefinition.Name };
				output.TargetSolution = TargetSolution;
				output.AddNamespace(TargetNamespace);
				output.TemplateName = "EnumTemplate";
				output.OutputDirectory = "Enums";

				foreach (var commentLine in GeneratedComments)
				{
					output.CommentLines.Add(commentLine);
				}

				foreach (var commentLine in enumDefinition.Comments)
				{
					output.CommentLines.Add(commentLine);
				}

				output.TypeDefinitions.Add(enumDefinition);

				if (enumDefinition.HasFlags)
				{
					output.AddStandardUsingDirective("System");
				}

				Generator.GenerateCodeFile(output);
				NumberCreated++;
			}
		}
	}
}
