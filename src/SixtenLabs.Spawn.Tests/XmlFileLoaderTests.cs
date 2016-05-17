using Xunit;
using FluentAssertions;
using NSubstitute;

namespace SixtenLabs.Spawn.Tests
{
	public class XmlFileLoaderTests
	{
		private XmlFileLoader<TestRegistry> SubjectUnderTest()
		{
			MockWebClientFactory = Substitute.For<IWebClientFactory>();
			MockGeneratorSettings = Substitute.For<IGeneratorSettings>();
			return new XmlFileLoader<TestRegistry>(MockGeneratorSettings, MockWebClientFactory);
		}

		[Fact]
		public void LoadRegistry_FromFile_RegistryIsLoaded()
		{
			var subject = SubjectUnderTest();

			MockGeneratorSettings.FileName.Returns("TestFiles/TestRegistryFile.xml");
			MockGeneratorSettings.LoadMethod.Returns(XmlLoadMethod.FromFile);

			subject.LoadRegistry();

			subject.Registry.Should().NotBeNull();
		}

		[Fact]
		public void LoadRegistry_FromUri_RegistryIsLoaded()
		{
			var subject = SubjectUnderTest();

			MockWebClientFactory.DownloadSpecFromUri(Arg.Any<string>()).Returns(TestRegistryFile);
			MockGeneratorSettings.WebUri.Returns("xxx");
			MockGeneratorSettings.LoadMethod.Returns(XmlLoadMethod.FromUri);

			subject.LoadRegistry();

			subject.Registry.Should().NotBeNull();
		}


		private IGeneratorSettings MockGeneratorSettings { get; set; }

		private IWebClientFactory MockWebClientFactory { get; set; }

		private string TestRegistryFile = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<TestRegistry>
  <name>Bob</name>
</TestRegistry>";
	}
}
