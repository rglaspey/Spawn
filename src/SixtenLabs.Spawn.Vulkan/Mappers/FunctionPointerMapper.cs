using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using System.Collections.Generic;

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
				var specNameRaw = text[i + 1];
				var specNameRawPrevious = text[i];

				var specName = specNameRaw.Replace(" ", "").Replace(",\n", "").Replace("*", "").Replace(");", "").Replace("const", "");

				var parameterDefinition = new ParameterDefinition() { SpecName = specName, SpecReturnType = (string)items[i] };

				//parameterDefinition.IsPointer = specNameRaw.StartsWith("*");
				//parameterDefinition.IsConst = specNameRawPrevious.Contains("const");

				parameters.Add(parameterDefinition);
			}

			return parameters;
		}
	}
}
