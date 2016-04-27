using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;

namespace SixtenLabs.Spawn.Vulkan
{
	public class ConstantMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryEnums, ClassDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.Fields, opt => opt.MapFrom(m => m.@enum));

			CreateMap<registryEnumsEnum, FieldDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.SpecReturnType, opt => opt.MapFrom(m => ProcessReturnType(m)))
				.ForMember(dest => dest.TranslatedReturnType, opt => opt.MapFrom(m => ProcessReturnType(m)))
				.ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(m => ProcessFieldReturnValue(m)));
		}

		private LiteralDefinition ProcessFieldReturnValue(registryEnumsEnum returnValue)
		{
			LiteralDefinition value = null;

			if (!string.IsNullOrEmpty(returnValue.value))
			{
				if (returnValue.value.Contains("f"))
				{
					value = new LiteralDefinition() { Value = returnValue.value.Replace("f", ""), LiteralType = typeof(float) };
				}
				else if (returnValue.value.Contains("(~0U)"))
				{
					value = new LiteralDefinition() { Value = "uint.MaxValue", LiteralType = typeof(uint) }; 
				}
				else if (returnValue.value.Contains("(~0ULL)"))
				{
					value = new LiteralDefinition() { Value = "ulong.MaxValue", LiteralType = typeof(ulong) };
				}
				else
				{
					value = new LiteralDefinition() { Value = returnValue.value, LiteralType = typeof(int) };
				}
			}

			return value;
		}

		private string ProcessReturnType(registryEnumsEnum ree)
		{
			string type = null;

			if (!string.IsNullOrEmpty(ree.value))
			{
				if (ree.value.Contains("f"))
				{
					type = "float";
				}
				else if (ree.value.Contains("(~0U)"))
				{
					type = "uint";
				}
				else if (ree.value.Contains("(~0ULL)"))
				{
					type = "ulong";
				}
				else
				{
					type = "uint";
				}
			}

			return type;
		}
	}
}
