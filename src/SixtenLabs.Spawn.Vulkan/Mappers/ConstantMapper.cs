using AutoMapper;

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
				.ForMember(dest => dest.SpecValue, opt => opt.MapFrom(m => m.value));
		}
	}
}
