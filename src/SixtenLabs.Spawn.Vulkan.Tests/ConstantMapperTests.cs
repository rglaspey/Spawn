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
	public class ConstantMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public ConstantMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ConstantMapper());
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
		public void Constants()
		{
			var vk = SubjectUnderTest();

			var types = vk.enums.Where(x => x.name == "API Constants");

			types.Should().HaveCount(1);

			var maps = new List<ClassDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<ClassDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(1);
		}

		private IMapper AMapper { get; }
	}
}
