using Xunit;
using FluentAssertions;
using NSubstitute;
using System;

using static System.Environment;

namespace SixtenLabs.Spawn.CSharp.Tests
{
	public class GenerateStructTests
	{
		private CSharpGenerator NewSubjectUnderTest()
		{
			MockSerializer = Substitute.For<IXmlSerializer>();
			MockSpawnService = Substitute.For<ISpawnService>();

			return new CSharpGenerator(MockSpawnService, MockSerializer);
		}

		[Fact]
		public void GenerateStruct_SpecNameNull_ThrowsException()
		{
			var subject = NewSubjectUnderTest();

			var output = new OutputDefinition();
			var structDef = new StructDefinition();

			Action act = () => subject.GenerateStruct(output, structDef);

			act.ShouldThrow<ArgumentNullException>("Struct must at least have a valid SpecName property set.");
		}

		[Fact]
		public void GenerateStruct_TranslatedNameNull_SpecNameUsed()
		{
			var subject = NewSubjectUnderTest();

			var output = new OutputDefinition();
			var structDef = new StructDefinition() { SpecName = "MyStruct" };

			var actual = subject.GenerateStruct(output, structDef);

			actual.Should().Be($"struct MyStruct{NewLine}{{{NewLine}}}");
		}

		[Fact]
		public void GenerateStruct_AddFieldNoReturnType_ThrowsException()
		{
			var subject = NewSubjectUnderTest();

			var output = new OutputDefinition();
			var structDef = new StructDefinition() { SpecName = "MyStruct" };
			structDef.Fields.Add(new FieldDefinition() { SpecName = "FieldName" });

			Action act = () => subject.GenerateStruct(output, structDef);

			act.ShouldThrow<ArgumentNullException>("Field must have a return type.");
		}

		[Fact]
		public void GenerateStruct_AddField_AddsField()
		{
			var subject = NewSubjectUnderTest();

			var output = new OutputDefinition();
			var structDef = new StructDefinition() { SpecName = "MyStruct" };
			structDef.Fields.Add(new FieldDefinition() { SpecName = "FieldName", SpecReturnType = "void" });

			var actual = subject.GenerateStruct(output, structDef);

			actual.Should().Be($"struct MyStruct{NewLine}{{{NewLine}    void FieldName;{NewLine}}}");
		}

		[Fact]
		public void GenerateStruct_NameSpace_AddsNamespace()
		{
			var subject = NewSubjectUnderTest();

			var nameSpaceDef = new NamespaceDefinition() { SpecName = "SixtenLabs.StructTest" };
			var output = new OutputDefinition() { Namespace = nameSpaceDef };
			var structDef = new StructDefinition() { SpecName = "MyStruct" };

			var actual = subject.GenerateStruct(output, structDef);

			actual.Should().Be($"namespace SixtenLabs.StructTest{NewLine}{{{NewLine}    struct MyStruct{NewLine}    {{{NewLine}    }}{NewLine}}}");
		}

		private IXmlSerializer MockSerializer { get; set; }

		private ISpawnService MockSpawnService { get; set; }
	}
}
