using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class InteropMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryCommand, MethodDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.proto.name))
				.ForMember(dest => dest.SpecReturnType, opt => opt.MapFrom(m => m.proto.type))
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(m => GetComments(m)))
				.ForMember(dest => dest.Parameters, opt => opt.MapFrom(m => m.param));

			CreateMap<registryCommandParam, ParameterDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.ExternSync, opt => opt.MapFrom(m => m.externsync == "true"))
				.ForMember(dest => dest.IsOptional, opt => opt.MapFrom(m => m.optional == "true"))
				.ForMember(dest => dest.IsPointer, opt => opt.MapFrom(m => IsPointer(m.Text)))
				.ForMember(dest => dest.IsConst, opt => opt.MapFrom(m => IsConst(m.Text)))
				.ForMember(dest => dest.SpecReturnType, opt => opt.MapFrom(m => m.type));
		}

		public List<string> GetComments(registryCommand command)
		{
			var comments = new List<string>();

			comments.AddRange(command.successcodes.Split(','));
			comments.AddRange(command.errorcodes.Split(','));

			if (command.validity != null)
			{
				comments.AddRange(command.validity);
			}

			return comments;
		}

		public bool IsPointer(string[] text)
		{
			return text != null && text.Any(x => x == "* ");
		}

		public bool IsConst(string[] text)
		{
			return text != null && text.Any(x => x == "const ");
		}
	}
}
