using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
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
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(m => AddComment(m.comment)))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(m => m.bitposSpecified ? Convert.ToString(m.bitpos) : m.value));
		}

		private CommentDefinition AddComment(string comment)
		{
			var commentDefinition = new CommentDefinition();

			if (!string.IsNullOrEmpty(comment))
			{
				commentDefinition.CommentLines.Add(comment);
			}

			return commentDefinition;
		}
	}
}
