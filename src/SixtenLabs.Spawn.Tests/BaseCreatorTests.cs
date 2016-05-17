using Xunit;
using FluentAssertions;
using NSubstitute;

namespace SixtenLabs.Spawn.Tests
{
	public class BaseCreatorTests
	{
		private TestCreator SubjectUnderTest()
		{
			MockCodeGenerator = Substitute.For<ICodeGenerator>();
			MockSpawnSpec = Substitute.For<ISpawnSpec<TestRegistry>>();

			return new TestCreator(MockCodeGenerator, MockSpawnSpec);
		}

		[Fact]
		public void TypeName_WhenCalled_ReturnsCorrectTypeName()
		{
			var subject = SubjectUnderTest();

			subject.TypeName.Should().Be("String");
		}

		[Fact]
		public void TargetSolution_WhenCalled_ReturnsCorrectTypeName()
		{
			var subject = SubjectUnderTest();

			subject.TargetSolution.Should().BeNull();
		}

		[Fact]
		public void TargetNamespace_WhenCalled_ReturnsCorrectTypeName()
		{
			var subject = SubjectUnderTest();

			subject.TargetNamespace.Should().BeNull();
		}

		[Fact]
		public void Off_WhenCalled_ReturnsCorrectTypeName()
		{
			var subject = SubjectUnderTest();

			subject.Off.Should().BeFalse();
		}

		private ICodeGenerator MockCodeGenerator { get; set; }

		private ISpawnSpec<TestRegistry> MockSpawnSpec { get; set; }
	}
}
