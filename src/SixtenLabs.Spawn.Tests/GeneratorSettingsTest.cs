using Xunit;
using FluentAssertions;

namespace SixtenLabs.Spawn.Tests
{
	public class GeneratorSettingsTest
	{
		private TestGeneratorSettings SubjectUnderTest()
		{
			return new TestGeneratorSettings();
		}

		[Fact]
		public void FileName_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.FileName.Should().Be("FileName");
		}

		[Fact]
		public void LoadMethod_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.LoadMethod.Should().Be(XmlLoadMethod.FromFile);
		}

		[Fact]
		public void WebUri_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.WebUri.Should().Be("uri");
		}

		[Fact]
		public void RootDirectory_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.RootDirectory.Should().Be(@"C:\");
		}

		[Fact]
		public void RootNameSpace_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.RootNamespace.Should().Be("RootNamespace");
		}

		[Fact]
		public void TargetSolutionName_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.TargetSolutionName.Should().Be("SolutionName");
		}

		[Fact]
		public void VersionToGenerate_ReturnsCorrectValue()
		{
			var subject = SubjectUnderTest();

			subject.VersionToGenerate.Should().Be("1.0.0.0");
		}
	}
}
