using System.Globalization;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;

namespace SixtenLabs.Spawn.Vulkan
{
	public class EnumCreator : BaseCreator
	{
		public EnumCreator(ISpawn spawn, ICodeGenerator generator, ICreatorRules rules)
			: base(spawn, generator, rules, "Enum", "Enum")
		{
		}

		private EnumDefinition GetEnumType(XElement enumElement)
		{
			var name = enumElement.Attribute("name").Value;
			var transformedName = Rules.TransformedName(name);

			var hasFlags = EnumHasFlags(name);
			var enumDefinition = new EnumDefinition(transformedName, hasFlags: hasFlags);
			GetEnumValues(enumDefinition, name, hasFlags);

			return enumDefinition;
		}

		private string TransformEnumName(string value)
		{
			var final = value.Replace("Vk", string.Empty);

			if (value.Contains("FlagBits"))
			{
				final = final.Replace("FlagBits", string.Empty);
			}

			return final;
		}

		private bool EnumHasFlags(string name)
		{
			var hasFlags = false;

			var values = Rules.SpecTree.Elements("enums").Where(x => (string)x.Attribute("name") == name);

			var firstValue = values.FirstOrDefault();

			if (firstValue != null)
			{
				var firstValueType = firstValue.Attribute("type");
				hasFlags = firstValueType != null && firstValueType.Value == "bitmask";
			}

			return hasFlags;
		}

		/// <summary>
		/// Change this to return types or anonymous types.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private void GetEnumValues(EnumDefinition enumDefinition, string name, bool hasFlags)
		{
			var values = Rules.SpecTree.Elements("enums").Where(x => (string)x.Attribute("name") == name);

			foreach(var enumValue in values.Elements("enum"))
			{
				var valueName = enumValue.Attribute("name").Value;
				var transformedEnumName = TransformEnumValueName(valueName);
				var transformedEnumValue = TransformEnumValueValue(enumValue, hasFlags);

				enumDefinition.AddEnumMember(transformedEnumName, transformedEnumValue);
			}
		}

		private string TransformEnumValueName(string value)
		{
			var vkRemoved = value.Replace("VK_", string.Empty);

			var splits = vkRemoved.Split('_');
			var textInfo = new CultureInfo("en-US", false).TextInfo;
			var builder = new StringBuilder();

			foreach (var split in splits)
			{
				var titleCase = textInfo.ToTitleCase(split.ToLower());
				builder.Append(titleCase);
			}

			var final = builder.ToString();

			return final;
		}

		private string TransformEnumValueValue(XElement value, bool hasFlags)
		{
			if (hasFlags)
			{
				return $"1 << {value.FirstAttribute.Value}";
			}
			else
			{
				return value.FirstAttribute.Value;
			}
		}

		public override void MapTypes()
		{
			var enumTypes = Rules.GetTypes("enum");

			foreach (var enumType in enumTypes)
			{
				var name = enumType.Attribute("name").Value;
				var transformedName = TransformEnumName(name);
				Rules.MapType(name, transformedName);
			}
		}

		public override void Build()
		{
			var enumElements = Rules.GetTypes("enum");

			foreach(var enumElement in enumElements)
			{
				var enumDefinition = GetEnumType(enumElement);
				EnumDefinitions.Add(enumDefinition);
			}
		}

		public override void Create()
		{
			foreach(var enumDefinition in EnumDefinitions)
			{
				if (enumDefinition.MemberValues.Count > 0)
				{
					var output = new OutputDefinition($"{enumDefinition.Name}.cs");
					output.AddNamespace(TargetNamespace);

					enumDefinition.AddModifier(SyntaxKindX.PublicKeyword);

					if (enumDefinition.HasFlags)
					{
						output.AddStandardUsingDirective("System");
					}

					var contents = Generator.GenerateEnum(output, enumDefinition);
					Spawn.AddDocumentToProject(TargetSolution, enumDefinition.Name, contents, new string[] { "Enums" });
					NumberCreated++;
				}
				else
				{
					// Do not make an enum for a type with no values...
				}
			}
		}

		private IList<EnumDefinition> EnumDefinitions { get; } = new List<EnumDefinition>();
	}
}
