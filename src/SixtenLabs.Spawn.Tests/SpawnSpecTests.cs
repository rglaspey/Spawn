using Xunit;
using FluentAssertions;
using NSubstitute;
using System;

namespace SixtenLabs.Spawn.Tests
{
	public class SpawnSpecTests
	{
		private TestSpec SubjectUnderTest()
		{
			MockWebClientFactory = Substitute.For<WebClientFactory>();
			MockGeneratorSettings = Substitute.For<IGeneratorSettings>();
			MockFileLoader = Substitute.For<XmlFileLoader<TestRegistry>>(MockGeneratorSettings, MockWebClientFactory);

			return new TestSpec(MockFileLoader);
		}

		[Fact]
		public void ProcessRegistry_FileLoader_LoadRegistryCalledOnce()
		{
			var subject = SubjectUnderTest();

			subject.ProcessRegistry();

			MockFileLoader.Received(1).LoadRegistry();
		}

		[Fact]
		public void GetTranslatedName_NoSpecTypeDefinitionExists_ThrowsException()
		{
			var subject = SubjectUnderTest();

			Action act = () => subject.GetTranslatedName("Bob");

			act.ShouldThrow<InvalidOperationException>($"Not allowed to not have a type mapping for: Bob");
		}

		[Fact]
		public void GetTranslatedChildName_NoSpecTypeDefinitionExists_ThrowsException()
		{
			var subject = SubjectUnderTest();

			Action act = () => subject.GetTranslatedChildName("Bob", "Timothy");

			act.ShouldThrow<InvalidOperationException>($"Not allowed to not have a type mapping for: Bob");
		}

		[Fact]
		public void GetTranslatedChildName_NoChildSpecTypeDefinitionExists_ThrowsException()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };
			subject.AddSpecTypeDefinition(specTypeDef);

			Action act = () => subject.GetTranslatedChildName("Robert", "Timothy");

			act.ShouldThrow<InvalidOperationException>($"Not allowed to not have a type mapping for: Timothy");
		}

		[Fact]
		public void AddSpecTypeDefinition_NewSpecDef_SpecTypeCountCorrect()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };

			subject.AddSpecTypeDefinition(specTypeDef);

			subject.SpecTypeCount.Should().Be(1);
		}
		
		[Fact]
		public void AddSpecTypeDefinition_SpecTypeDefinitionExists_ThrowsException()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };
			subject.AddSpecTypeDefinition(specTypeDef);

			Action act = () => subject.AddSpecTypeDefinition(specTypeDef);

			act.ShouldThrow<InvalidOperationException>($"SpecTypeDefinition for {specTypeDef.SpecName} already exists.");
		}

		[Fact]
		public void GetTranslatedName_SpecTypeExists_ReturnsTranslatedName()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };
			subject.AddSpecTypeDefinition(specTypeDef);

			var actual = subject.GetTranslatedName("Robert");

			actual.Should().Be("Bob");
		}

		[Fact]
		public void GetTranslatedChildName_SpecTypeExists_ReturnsTranslatedName()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };
			specTypeDef.Children.Add(new SpecTypeDefinition() { SpecName = "Timothy", TranslatedName = "Tim" });
			subject.AddSpecTypeDefinition(specTypeDef);

			var actual = subject.GetTranslatedChildName("Robert", "Timothy");

			actual.Should().Be("Tim");
		}

		[Fact]
		public void SpecTree_xx_xx()
		{
			var subject = SubjectUnderTest();

			var specTypeDef = new SpecTypeDefinition() { SpecName = "Robert", TranslatedName = "Bob" };
			subject.AddSpecTypeDefinition(specTypeDef);

			var actual = subject.SpecTree;

			MockFileLoader.Received(1).Registry = null;
		}

		private IGeneratorSettings MockGeneratorSettings { get; set; }

		private XmlFileLoader<TestRegistry> MockFileLoader { get; set; }

		private IWebClientFactory MockWebClientFactory { get; set; }
	}
}
