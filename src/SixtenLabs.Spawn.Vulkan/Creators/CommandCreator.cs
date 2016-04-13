using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class CommandCreator : BaseCreator<registry, ImportDefinition>
	{
		public CommandCreator(ICodeGenerator generator, ISpawnSpec<registry> vulkanSpec)
			: base(generator, vulkanSpec, 50)
		{
		}

		public override int Rewrite()
		{
			return 0;
		}

		private void ProcessParameterText(ParameterDefinition parameterDefinition, string[] text)
		{
			if (text != null)
			{
				foreach (var symbol in text)
				{
					if (symbol.TrimEnd() == "const")
					{
						parameterDefinition.IsConst = true;
					}
					else if (symbol.TrimEnd() == "*")
					{
						parameterDefinition.IsPointer = true;
					}
					else if (symbol.TrimEnd() == "**")
					{
						parameterDefinition.IsPointerToPointer = true;
					}
					else if (symbol.TrimEnd() == "struct")
					{
						parameterDefinition.IsStruct = true;
					}
					else if (symbol.StartsWith("[") && symbol.EndsWith("]"))
					{
						parameterDefinition.IsArray = true;
						parameterDefinition.ArrayCount = Convert.ToInt32(symbol.Substring(1, symbol.Length - 2));
					}
					else
					{
						var blah = symbol;
					}
				}
			}
		}

		private void AddParameters(ImportDefinition importDefinition, registryCommandParam[] parameters)
		{
			foreach (var registryParam in parameters)
			{
				var parameterDefinition = new ParameterDefinition();

				parameterDefinition.SpecName = registryParam.name;
				parameterDefinition.TranslatedName = registryParam.name.TranslateParameter();
				parameterDefinition.SpecType = registryParam.type;
				parameterDefinition.TranslatedSpecType = VulkanSpec.FindTypeDefinition(registryParam.type).TranslatedName;
				parameterDefinition.IsOptional = registryParam.optional == "true" ? true : false;

				// handle len property

				// get validity comments if any

				// This is wrong. should be text or parsed...
				parameterDefinition.ExternSync = registryParam.externsync == "true" ? true : false;

				ProcessParameterText(parameterDefinition, registryParam.Text);

				importDefinition.Parameters.Add(parameterDefinition);
			}
		}

		public override int Build()
		{
			var registryCommands = VulkanSpec.SpecTree.commands;

			foreach(var registryCommand in registryCommands)
			{
				var specName = registryCommand.proto.name;
				var translatedName = specName.TranslateVulkanName();

				var specType = registryCommand.proto.type;
				var translatedType = VulkanSpec.FindTypeDefinition(specType).TranslatedName;

				var importDefinition = new ImportDefinition();

				importDefinition.SpecName = specName;
				importDefinition.TranslatedName = translatedName;
				importDefinition.SpecDerivedType = specType;
				importDefinition.DerivedType = translatedType;
 
				AddParameters(importDefinition, registryCommand.param);

				// Add success codes and error codes

				VulkanSpec.AddSpecType(specName, translatedName);

				Definitions.Add(importDefinition);
			}

			return Definitions.Count;
		}

		public override int Create()
		{
			return 0;
		}
	}
}
