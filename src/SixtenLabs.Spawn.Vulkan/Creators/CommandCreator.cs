using SixtenLabs.Spawn.Utility;
using System;

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

		private void ProcessSuccessCodes(ImportDefinition importDefinition, string successCodes)
		{
			if (!string.IsNullOrEmpty(successCodes))
			{
				var codes = successCodes.Split(',');

				foreach(var code in codes)
				{
					importDefinition.AddSuccessCodes(code);
				}
			}
		}

		private void ProcessErrorCodes(ImportDefinition importDefinition, string errorCodes)
		{
			if (!string.IsNullOrEmpty(errorCodes))
			{
				var codes = errorCodes.Split(',');

				foreach (var code in codes)
				{
					importDefinition.AddErrorCodes(code);
				}
			}
		}

		private void ProcessValidity(ImportDefinition importDefinition, string[] validity)
		{
			if (validity != null)
			{
				foreach (var validEntry in validity)
				{
					importDefinition.Comments.Add(validEntry);
				}
			}
		}

		private void ProcessExternSync(ParameterDefinition parameterDefinition, string externSync)
		{
			if (!string.IsNullOrEmpty(externSync))
			{
				if (externSync == "true")
				{
					parameterDefinition.ExternSync = true;
				}
				else
				{
					// should we set the bool to true?
					parameterDefinition.ExternSyncData = externSync;
				}
			}
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
				parameterDefinition.TranslatedName = registryParam.name;
				parameterDefinition.SpecType = registryParam.type;
				parameterDefinition.TranslatedSpecType = VulkanSpec.FindTypeDefinition(registryParam.type).TranslatedName;

				parameterDefinition.IsOptional = registryParam.optional == "true" ? true : false;
				parameterDefinition.LengthPropertyName = registryParam.len;
				ProcessExternSync(parameterDefinition, registryParam.externsync);

				ProcessParameterText(parameterDefinition, registryParam.Text);

				importDefinition.Parameters.Add(parameterDefinition);
			}
		}

		public override int Build()
		{
			var registryCommands = VulkanSpec.SpecTree.commands;

			foreach (var registryCommand in registryCommands)
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
				ProcessValidity(importDefinition, registryCommand.validity);
				ProcessSuccessCodes(importDefinition, registryCommand.successcodes);
				ProcessErrorCodes(importDefinition, registryCommand.errorcodes);

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
