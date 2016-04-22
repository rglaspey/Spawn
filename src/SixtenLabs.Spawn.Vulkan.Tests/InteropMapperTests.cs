using Xunit;
using FluentAssertions;
using NSubstitute;

using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan.Tests
{
	public class InteropMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public InteropMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new InteropMapper());
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
		public void MapAllCommands()
		{
			var vk = SubjectUnderTest();

			var commands = vk.commands;

			commands.Should().HaveCount(169);

			var maps = new List<MethodDefinition>();

			foreach (var type in commands)
			{
				var map = AMapper.Map<MethodDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(169);
		}

		[Fact]
		public void MapVkInstanceHandle()
		{
			var vk = SubjectUnderTest();

			var type = vk.commands.Where(x => x.proto.name == "vkCreateInstance").FirstOrDefault();

			var map = AMapper.Map<MethodDefinition>(type);

			map.SpecName.Should().Be("vkCreateInstance");
			map.SpecReturnType.Should().Be("VkResult");
			map.Parameters.Should().HaveCount(3);

			map.Parameters[0].SpecName.Should().Be("pCreateInfo");
			map.Parameters[0].SpecReturnType.Should().Be("VkInstanceCreateInfo");
			map.Parameters[0].ExternSync.Should().BeFalse();
			map.Parameters[0].IsOptional.Should().BeFalse();
			map.Parameters[0].IsPointer.Should().BeTrue();

			map.Parameters[1].SpecName.Should().Be("pAllocator");
			map.Parameters[1].SpecReturnType.Should().Be("VkAllocationCallbacks");
			map.Parameters[1].ExternSync.Should().BeFalse();
			map.Parameters[1].IsOptional.Should().BeTrue();
			map.Parameters[1].IsPointer.Should().BeTrue();

			map.Parameters[2].SpecName.Should().Be("pInstance");
			map.Parameters[2].SpecReturnType.Should().Be("VkInstance");
			map.Parameters[2].ExternSync.Should().BeFalse();
			map.Parameters[2].IsOptional.Should().BeFalse();
			map.Parameters[2].IsPointer.Should().BeTrue();
		}

		private IMapper AMapper { get; }
	}
}
