using Xunit;
using FluentAssertions;
using NSubstitute;

using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;

namespace SixtenLabs.Spawn.Vulkan.Tests
{
	public class FunctionPointerMapperTests
	{
		private XmlFileLoader<registry> FileLoader { get; set; }

		private VulkanSettings Settings { get; } = new VulkanSettings();

		public FunctionPointerMapperTests()
		{
			FileLoader = new XmlFileLoader<registry>(Settings);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new FunctionPointerMapper());
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

			var types = vk.types.Where(x => x.category == "funcpointer");

			types.Should().HaveCount(7);

			var maps = new List<DelegateDefinition>();

			foreach (var type in types)
			{
				var map = AMapper.Map<DelegateDefinition>(type);
				maps.Add(map);
			}

			maps.Should().HaveCount(7);
		}

		[Fact]
		public void Map_PFN_vkInternalAllocationNotification()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "funcpointer" && (string)x.Items[0] == "PFN_vkInternalAllocationNotification").FirstOrDefault();

			var map = AMapper.Map<DelegateDefinition>(type);

			map.SpecName.Should().Be("PFN_vkInternalAllocationNotification");
		}

		[Fact]
		public void Map_PFN_vkInternalFreeNotification()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "funcpointer" && (string)x.Items[0] == "PFN_vkInternalFreeNotification").FirstOrDefault();

			var map = AMapper.Map<DelegateDefinition>(type);

			map.SpecName.Should().Be("PFN_vkInternalFreeNotification");
			map.SpecReturnType.Should().Be("void");
			map.Parameters.Should().HaveCount(4);
			map.Parameters[0].SpecName.Should().Be("pUserData");
			map.Parameters[0].SpecReturnType.Should().Be("void");
			map.Parameters[0].IsPointer.Should().BeTrue();
			map.Parameters[1].SpecName.Should().Be("size");
			map.Parameters[1].SpecReturnType.Should().Be("size_t");
			map.Parameters[1].IsPointer.Should().BeFalse();
			map.Parameters[2].SpecName.Should().Be("allocationType");
			map.Parameters[2].SpecReturnType.Should().Be("VkInternalAllocationType");
			map.Parameters[2].IsPointer.Should().BeFalse();
			map.Parameters[3].SpecName.Should().Be("allocationScope");
			map.Parameters[3].SpecReturnType.Should().Be("VkSystemAllocationScope");
			map.Parameters[3].IsPointer.Should().BeFalse();
		}

		[Fact]
		public void Map_PFN_vkReallocationFunction()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "funcpointer" && (string)x.Items[0] == "PFN_vkReallocationFunction").FirstOrDefault();

			var map = AMapper.Map<DelegateDefinition>(type);

			map.SpecName.Should().Be("PFN_vkReallocationFunction");
			map.SpecReturnType.Should().Be("void*");
			map.Parameters.Should().HaveCount(5);
			map.Parameters[0].SpecName.Should().Be("pUserData");
			map.Parameters[0].SpecReturnType.Should().Be("void");
			map.Parameters[0].IsPointer.Should().BeTrue();
			map.Parameters[0].IsConst.Should().BeFalse();
			map.Parameters[1].SpecName.Should().Be("pOriginal");
			map.Parameters[1].SpecReturnType.Should().Be("void");
			map.Parameters[1].IsPointer.Should().BeTrue();
			map.Parameters[1].IsConst.Should().BeFalse();
			map.Parameters[2].SpecName.Should().Be("size");
			map.Parameters[2].SpecReturnType.Should().Be("size_t");
			map.Parameters[2].IsPointer.Should().BeFalse();
			map.Parameters[2].IsConst.Should().BeFalse();
			map.Parameters[3].SpecName.Should().Be("alignment");
			map.Parameters[3].SpecReturnType.Should().Be("size_t");
			map.Parameters[3].IsPointer.Should().BeFalse();
			map.Parameters[3].IsConst.Should().BeFalse();
			map.Parameters[4].SpecName.Should().Be("allocationScope");
			map.Parameters[4].SpecReturnType.Should().Be("VkSystemAllocationScope");
			map.Parameters[4].IsPointer.Should().BeFalse();
			map.Parameters[4].IsConst.Should().BeFalse();
		}

		[Fact]
		public void Map_PFN_vkVoidFunction()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "funcpointer" && (string)x.Items[0] == "PFN_vkVoidFunction").FirstOrDefault();

			var map = AMapper.Map<DelegateDefinition>(type);

			map.SpecName.Should().Be("PFN_vkVoidFunction");
			map.SpecReturnType.Should().Be("void");
			map.Parameters.Should().HaveCount(0);
		}

		[Fact]
		public void Map_PFN_PFN_vkDebugReportCallbackEXT()
		{
			var vk = SubjectUnderTest();

			var type = vk.types.Where(x => x.category == "funcpointer" && (string)x.Items[0] == "PFN_vkDebugReportCallbackEXT").FirstOrDefault();

			var map = AMapper.Map<DelegateDefinition>(type);

			map.SpecName.Should().Be("PFN_vkDebugReportCallbackEXT");
			map.SpecReturnType.Should().Be("VkBool32");
			map.Parameters.Should().HaveCount(8);
			map.Parameters[0].SpecName.Should().Be("flags");
			map.Parameters[0].SpecReturnType.Should().Be("VkDebugReportFlagsEXT");
			map.Parameters[0].IsPointer.Should().BeFalse();
			map.Parameters[0].IsConst.Should().BeFalse();
			map.Parameters[1].SpecName.Should().Be("objectType");
			map.Parameters[1].SpecReturnType.Should().Be("VkDebugReportObjectTypeEXT");
			map.Parameters[1].IsPointer.Should().BeFalse();
			map.Parameters[1].IsConst.Should().BeFalse();
			map.Parameters[2].SpecName.Should().Be("object");
			map.Parameters[2].SpecReturnType.Should().Be("uint64_t");
			map.Parameters[2].IsPointer.Should().BeFalse();
			map.Parameters[2].IsConst.Should().BeFalse();
			map.Parameters[3].SpecName.Should().Be("location");
			map.Parameters[3].SpecReturnType.Should().Be("size_t");
			map.Parameters[3].IsPointer.Should().BeFalse();
			map.Parameters[3].IsConst.Should().BeFalse();
			map.Parameters[4].SpecName.Should().Be("messageCode");
			map.Parameters[4].SpecReturnType.Should().Be("int32_t");
			map.Parameters[4].IsPointer.Should().BeFalse();
			map.Parameters[4].IsConst.Should().BeFalse();
			map.Parameters[5].SpecName.Should().Be("pLayerPrefix");
			map.Parameters[5].SpecReturnType.Should().Be("char");
			map.Parameters[5].IsPointer.Should().BeTrue();
			map.Parameters[5].IsConst.Should().BeTrue();
			map.Parameters[6].SpecName.Should().Be("pMessage");
			map.Parameters[6].SpecReturnType.Should().Be("char");
			map.Parameters[6].IsPointer.Should().BeTrue();
			map.Parameters[6].IsConst.Should().BeTrue();
			map.Parameters[7].SpecName.Should().Be("pUserData");
			map.Parameters[7].SpecReturnType.Should().Be("void");
			map.Parameters[7].IsPointer.Should().BeTrue();
			map.Parameters[7].IsConst.Should().BeFalse();
		}

		private IMapper AMapper { get; }
	}
}
