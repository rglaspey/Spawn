using AutoMapper;
using System;

namespace SixtenLabs.Spawn.Vulkan
{
	public class HandleMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryType, ClassDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.Items[1]))
				.ForMember(dest => dest.SpecDerivedType, opt => opt.MapFrom(m => m.parent));
		}
	}
}
