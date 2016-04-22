using AutoMapper;
using System;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	/// <summary>
	/// Validity array poses interesting issue on how to map the 
	/// usage strings with the correct parameters, or maybe just dump on comments for the struct
	/// </summary>
	public class StructMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryType, StructDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.Fields, opt => opt.MapFrom(m => m.Items.Where(x => x.GetType() == typeof(registryTypeMember))));

			CreateMap<registryTypeMember, FieldDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.SpecType, opt => opt.MapFrom(m => m.@type));

			//CreateMap<registryTypeValidity, CommentLineDefinition>()
			//	.ForMember(dest => dest.Text, opt => opt.MapFrom(m => m.usage));
		}
	}
}
