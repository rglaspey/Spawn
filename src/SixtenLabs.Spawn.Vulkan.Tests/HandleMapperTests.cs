using Xunit;
using FluentAssertions;
using NSubstitute;

using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Generator.CSharp;

namespace SixtenLabs.Spawn.Vulkan.Tests
{
	public class HandleMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public HandleMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new RegistryTypeMapper());
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
		public void MapAllHandles()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "handle");

			types.Should().HaveCount(30);

			var maps = new List<StructDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<StructDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(30);
		}

		[Fact]
		public void MapVkInstanceHandle()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "handle" && (string)x.Items[1] == "VkInstance").FirstOrDefault();

			var map = AMapper.Map<StructDefinition>(type);

			map.SpecName.Should().Be("VkInstance");
			map.SpecDerivedType.Should().BeNull();
		}

		//[Fact]
		//public void MapVkInstanceHandle()
		//{
		//	var vk = SubjectUnderTest();

		//	var type = vk.types.Where(x => x.category == "handle" && (string)x.Items[1] == "VkInstance").FirstOrDefault();

		//	var map = AMapper.Map<StructDefinition>(type);

		//	map.SpecName.Should().Be("VkInstance");
		//	map.SpecDerivedType.Should().BeNull();
		//}

		[Fact]
		public void MapVkCommandBufferHandle()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "handle" && (string)x.Items[1] == "VkCommandBuffer").FirstOrDefault();

			var map = AMapper.Map<StructDefinition>(type);
			 
			map.SpecName.Should().Be("VkCommandBuffer");
			map.SpecDerivedType.Should().Be("VkCommandPool");
		}

		private IMapper AMapper { get; }
	}
}
