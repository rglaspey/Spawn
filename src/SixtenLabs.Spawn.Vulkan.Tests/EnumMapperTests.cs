using Xunit;
using FluentAssertions;
using NSubstitute;

using AutoMapper;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan.Tests
{
	public class EnumMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public EnumMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new EnumMapper());
			});

			Mapper.AssertConfigurationIsValid();

			AMapper = config.CreateMapper();
		}

		private registry SubjectUnderTest()
		{
			FileLoader.LoadRegistry();

			return FileLoader.Registry;
		}

		[Fact]
		public void MapAllEnums()
		{
			var vk = SubjectUnderTest();

			var types = vk.enums.Where(x => x.name != "API Constants");

			types.Should().HaveCount(73);

			var maps = new List<EnumDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<EnumDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(73);
		}

		[Fact]
		public void MapNonFlagsEnum()
		{
			var vk = SubjectUnderTest();

			var type = vk.enums.Where(x => x.name == "VkImageLayout").FirstOrDefault();

			var map = AMapper.Map<EnumDefinition>(type);

			map.SpecName.Should().Be("VkImageLayout");
			//map.TranslatedName.Should().Be("ImageLayout");
			map.HasFlags.Should().BeFalse();
			map.Members.Should().HaveCount(9);
		}

		[Fact]
		public void MapFlagsEnum()
		{
			var vk = SubjectUnderTest();

			var type = vk.enums.Where(x => x.name == "VkQueueFlagBits").FirstOrDefault();

			var map = AMapper.Map<EnumDefinition>(type);

			map.SpecName.Should().Be("VkQueueFlagBits");
			//map.TranslatedName.Should().Be("QueueFlags");
			map.HasFlags.Should().BeTrue();
			map.Members.Should().HaveCount(4);
		}

		private IMapper AMapper { get; }
	}
}
