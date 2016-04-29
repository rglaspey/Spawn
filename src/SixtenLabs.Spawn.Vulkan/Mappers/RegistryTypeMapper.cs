using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using System.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class RegistryTypeMapper : Profile
	{
		protected override void Configure()
		{
			CreateMap<registryType, StructDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => MapSpecName(m)))
				.ForMember(dest => dest.SpecDerivedType, opt => opt.MapFrom(m => m.parent))
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(m => MapComments(m.comment)))
				.ForMember(dest => dest.Fields, opt => opt.MapFrom(m => m.Items.Where(x => x.GetType() == typeof(registryTypeMember))));

			CreateMap<registryTypeMember, FieldDefinition>()
				.ForMember(dest => dest.SpecName, opt => opt.MapFrom(m => m.name))
				.ForMember(dest => dest.SpecReturnType, opt => opt.MapFrom(m => m.type))
				.ForMember(dest => dest.SpecType, opt => opt.MapFrom(m => m.@type));
		}

		private string MapSpecName(registryType rt)
		{
			if(rt.category == "struct")
			{
				return rt.name;
			}
			else if(rt.category == "handle")
			{
				return rt.Items[1] as string;
			}
			else if (rt.category == "union")
			{
				return rt.name as string;
			}
			else
			{
				return null;
			}
		}

		private CommentDefinition MapComments(string comment)
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
