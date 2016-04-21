using AutoMapper;
using System;

namespace SixtenLabs.Spawn.Vulkan
{
	public class EnumMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryEnums, EnumDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.HasFlags, opt => opt.MapFrom(m => m.type == "bitmask"))
				.ForMember(dest => dest.Members, opt => opt.MapFrom(m => m.@enum));

			CreateMap<registryEnumsEnum, EnumMemberDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.Comment, opt => opt.MapFrom(m => m.comment))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(m => m.bitposSpecified ? Convert.ToString(m.bitpos) : m.value));
		}
	}
}
