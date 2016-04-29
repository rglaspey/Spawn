using AutoMapper;
using SixtenLabs.Spawn.Generator.CSharp;
using System;

namespace SixtenLabs.Spawn.Vulkan
{
	public class RegistryEnumMapper : Profile
	{
		/// <summary>
		/// There is one oddball defined enum that actually need to be mapped
		/// as a static class with constant values.
		/// </summary>
		private void ConfigureApiConstantsMapping()
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

		private void ConfigureEnumMapping()
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

		protected override void Configure()
		{
			ConfigureEnumMapping();
			ConfigureApiConstantsMapping();
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
