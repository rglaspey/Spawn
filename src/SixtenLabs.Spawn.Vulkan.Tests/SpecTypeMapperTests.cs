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
	public class SpecTypeMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public SpecTypeMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new SpecTypeMapper());
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
		public void all_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types;

			types.Should().HaveCount(374);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(374);
			var nullTranslatedNameMaps = maps.Where(x => x.TranslatedName == null);
			nullTranslatedNameMaps.Count(x => x.TranslatedName == null).Should().Be(0);

			var nullSpecNameMaps = maps.Where(x => x.SpecName == null);
			nullSpecNameMaps.Count(x => x.SpecName == null).Should().Be(0);
		}

		[Fact]
		public void vkPlatform_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.requires == "vk_platform");
			
			types.Should().HaveCount(8);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(8);
		}

		[Fact]
		public void requiresNotEnums_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => !string.IsNullOrEmpty(x.requires) && !x.requires.Contains("Bits"));

			types.Should().HaveCount(21);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(21);
		}

		[Fact]
		public void basetype_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "basetype");

			types.Should().HaveCount(4);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(4);
		}

		[Fact]
		public void bitmask_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "bitmask");

			types.Should().HaveCount(71);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(71);
		}

		[Fact]
		public void handle_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "handle");

			types.Should().HaveCount(30);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(30);
		}

		[Fact]
		public void enum_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "enum");

			types.Should().HaveCount(95);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(95);
		}

		[Fact]
		public void funcpointer_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "funcpointer");

			types.Should().HaveCount(7);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(7);
		}

		[Fact]
		public void struct_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "struct");

			types.Should().HaveCount(126);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(126);
		}

		[Fact]
		public void union_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "union");

			types.Should().HaveCount(2);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(2);
		}

		[Fact]
		public void include_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "include");

			types.Should().HaveCount(8);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(8);
		}

		[Fact]
		public void define_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.types.Where(x => x.category == "define");

			types.Should().HaveCount(10);

			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(10);
		}

		[Fact]
		public void enumValues_Types_Process()
		{
			var vk = SubjectUnderTest();

			var types = vk.enums.Where(x => x.name != "API Constants").SelectMany(x => x.@enum);
			types.Should().HaveCount(623);
		
			var maps = GetMapsFromTypes(types);

			maps.Should().HaveCount(623);
		}

		private IList<SpecTypeDefinition> GetMapsFromTypes<T>(IEnumerable<T> types) where T : class
		{
			var maps = new List<SpecTypeDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<SpecTypeDefinition>(type);
				maps.Add(map);
			}

			return maps;
		}

		private IMapper AMapper { get; }
	}
}
