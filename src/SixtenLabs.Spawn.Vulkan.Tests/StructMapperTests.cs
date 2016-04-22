using Xunit;
using FluentAssertions;
using NSubstitute;

using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan.Tests
{
	public class StructMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public StructMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new StructMapper());
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
		public void MapAllStructs()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "struct");

			types.Should().HaveCount(125);

			var maps = new List<StructDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<StructDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(125);
		}

		[Fact]
		public void MapVkOffset2DStruct()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "struct" && x.name == "VkOffset2D").FirstOrDefault();

			var map = AMapper.Map<StructDefinition>(type);

			map.SpecName.Should().Be("VkOffset2D");
			map.Fields.Should().HaveCount(2);
		}

		[Fact]
		public void MapVkPhysicalDevicePropertiesStruct()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "struct" && x.name == "VkPhysicalDeviceProperties").FirstOrDefault();

			var map = AMapper.Map<StructDefinition>(type);

			map.SpecName.Should().Be("VkPhysicalDeviceProperties");
			map.Fields.Should().HaveCount(9);
		}

		[Fact]
		public void MapVkViewportStruct()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "struct" && x.name == "VkViewport").FirstOrDefault();

			var map = AMapper.Map<StructDefinition>(type);

			map.SpecName.Should().Be("VkViewport");
			map.Fields.Should().HaveCount(6);
		}

		private IMapper AMapper { get; }
	}
}
