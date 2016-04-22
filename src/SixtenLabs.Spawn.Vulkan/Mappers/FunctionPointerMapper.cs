using AutoMapper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SixtenLabs.Spawn.Vulkan
{
	public class FunctionPointerMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryType, DelegateDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.Items[0]))
				.ForMember(dest => dest.SpecReturnType, opt => opt.MapFrom(m => GetReturnType(m.Text)))
				.ForMember(dest => dest.Parameters, opt => opt.MapFrom(m => GetParameters(m.Items, m.Text)));
		}

		public string GetReturnType(string[] text)
		{
			return text[0].Replace(" (VKAPI_PTR *", "").Replace("typedef ", "");
		}

		private IList<ParameterDefinition> GetParameters(object[] items, string[] text)
		{
			var parameters = new List<ParameterDefinition>();

			for(int i = 1; i < items.Length; i++)
			{
				var parameterDefinition = new ParameterDefinition();

				var specNameRaw = text[i + 1];
				var specNameRawPrevious = text[i];

				parameterDefinition.SpecName = specNameRaw.Replace(" ", "").Replace(",\n", "").Replace("*", "").Replace(");", "").Replace("const", "");
				parameterDefinition.SpecReturnType = (string)items[i];
				parameterDefinition.IsPointer = specNameRaw.StartsWith("*");
				parameterDefinition.IsConst = specNameRawPrevious.Contains("const");

				parameters.Add(parameterDefinition);
			}

			return parameters;
		}
	}
}
