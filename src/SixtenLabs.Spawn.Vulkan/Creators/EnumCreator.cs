using System.Linq;
using System.Xml.Linq;
using SixtenLabs.Spawn.Utility;
using System;
using System.Text.RegularExpressions;

namespace SixtenLabs.Spawn.Vulkan
{
	public class EnumCreator : BaseCreator<registry, EnumDefinition>
	{
		public EnumCreator(ICodeGenerator generator, ISpawnSpec<registry> spawnSpec)
			: base(generator, spawnSpec, 10)
		{
		}

		private EnumDefinition ReadEnum(registryEnums registryEnum)
		{
			var enumDefinition = new EnumDefinition();

			enumDefinition.SpecName = registryEnum.name;
			enumDefinition.TranslatedName = registryEnum.name.TranslateVulkanName();
			enumDefinition.HasFlags = registryEnum.type == "bitmask";
			enumDefinition.Expand = registryEnum.expand;
			enumDefinition.Namespace = registryEnum.@namespace;
			enumDefinition.Comments.Add(registryEnum.comment);

			if (enumDefinition.HasFlags)
			{
				// Get Type
				var type = VulkanSpec.SpecTree.types.Where(x => x.category == "bitmask" && x.requires == enumDefinition.SpecName).FirstOrDefault();

				if (type != null)
				{
					enumDefinition.SpecDerivedType = type.Items[1] as string;
				}
			}

			if (string.IsNullOrEmpty(enumDefinition.SpecName))
			{
				throw new InvalidOperationException("Enum collection does not have proper `<name>` element");
			}

			// note: there are also `unused` blocks that are not currently used...
			var enumValues = registryEnum.@enum.AsEnumerable().Select(ReadEnumValue);
			enumDefinition.AddEnumMembers(enumValues);

			return enumDefinition;
		}

		private EnumMemberDefinition ReadEnumValue(registryEnumsEnum enumElement)
		{
			var enumMemberDefinition = new EnumMemberDefinition();

			enumMemberDefinition.SpecName = enumElement.name;
			enumMemberDefinition.TranslatedName = enumElement.name.TranslateVulkanName();
			enumMemberDefinition.Value = enumElement.bitposSpecified ? Convert.ToString(enumElement.bitpos) : enumElement.value;
			enumMemberDefinition.Comment = enumElement.comment;

			if (string.IsNullOrEmpty(enumMemberDefinition.TranslatedName) || string.IsNullOrEmpty(enumMemberDefinition.Value))
			{
				throw new InvalidOperationException("Enum collection does not have proper `<name>` or `<value>` or `<bitpos>` element");
			}

			VulkanSpec.AddSpecType(enumMemberDefinition.SpecName, enumMemberDefinition.TranslatedName);

			return enumMemberDefinition;
		}

		private string FormatFlagValue(int pos)
		{
			return string.Format("0x{0:X}", 1 << pos);
		}

		private string EnumExtensionValue(registryExtensionRequireEnum element, int number, ref string csEnumName)
		{
			var offsetAttribute = element.offset;

			if (offsetAttribute != null)
			{
				int direction = 1;
				var dirAttr = element.dir;

				if (dirAttr != null && dirAttr == "-")
				{
					direction = -1;
				}

				int offset = offsetAttribute;

				return (direction * (1000000000 + (number - 1) * 1000 + offset)).ToString();
			}

			var valueAttribute = element.value;

			if (valueAttribute != null)
			{
				return valueAttribute;
			}

			//var bitposAttribute = element.;

			//if (bitposAttribute != null)
			//{
			//	if (csEnumName.EndsWith("FlagBits"))
			//	{
			//		csEnumName = csEnumName.Substring(0, csEnumName.Length - 4) + "s";
			//	}

			//	return FormatFlagValue(Int32.Parse(bitposAttribute));
			//}

			throw new Exception(string.Format("unexpected extension enum value in: {0}", element));
		}

		private void MapEnumExtensions()
		{
			var extensionElements = VulkanSpec.SpecTree.extensions.Where(x => x.supported != "disabled");

			foreach (var extensionElement in extensionElements)
			{
				var extensions = extensionElement.require.@enum.Where(x => x.extends != null);
				int number = extensionElement.number;

				foreach (var element in extensions)
				{
					string enumSpecName = element.extends;

					if (Definitions.Any(x => x.SpecName == enumSpecName))
					{
						var enumDefinition = Definitions.Where(x => x.SpecName == enumSpecName).FirstOrDefault();

						var specName = element.name;
						var translatedName = specName.TranslateVulkanName();
						var value = EnumExtensionValue(element, number, ref enumSpecName);
						enumDefinition.AddEnumMember(specName, translatedName, value, "Extension Enum Value");

						VulkanSpec.AddSpecType(specName, translatedName);
					}
				}
			}
		}

		public override int Rewrite()
		{
			//foreach (var vkEnum in VulkanSpec.Enums)
			//{
			//	vkEnum.Name = vkEnum.SpecName.TranslateVulkanName();

			//	foreach (var vkEnumValue in vkEnum.Members)
			//	{
			//		vkEnumValue.Name = TranslateEnumMemberName(vkEnumValue.SpecName);
			//	}

			//	// After the we've renamed all the enum values, check if there are any that
			//	// begin with a number (invalid in C#) and fix it.
			//	if (vkEnum.Members.Any(x => Regex.IsMatch(x.Name, "^[0-9]")))
			//	{
			//		foreach (var vkEnumValue in vkEnum.Members)
			//		{
			//			var name = vkEnumValue.Name;
			//			name = vkEnum.Name + name;
			//			vkEnumValue.Name = name;
			//		}
			//	}
			//}

			return 0;
		}

		public override int Build()
		{
			var registryEnums = VulkanSpec.SpecTree.enums;

			foreach(var registryEnum in registryEnums)
			{
				var enumDefinition = ReadEnum(registryEnum);
				Definitions.Add(enumDefinition);
			}

			return Definitions.Count;
		}

		public override int Create()
		{
			int count = 0;

			foreach (var enumDefinition in Definitions)
			{
				var output = new OutputDefinition<EnumDefinition>() { FileName = enumDefinition.TranslatedName };
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
				count++;
			}

			return count;
		}
	}
}
