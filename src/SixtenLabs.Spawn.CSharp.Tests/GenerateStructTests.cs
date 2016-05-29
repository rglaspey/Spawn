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
			MockSpawnService = Substitute.For<ISpawnService>();

			return new CSharpGenerator(MockSpawnService);
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

		[Fact]
		public void GenerateStruct_AddAttribute_AddsAttribute()
		{
			var subject = NewSubjectUnderTest();

			var output = new OutputDefinition();
			var attribute = new AttributeDefinition() { SpecName = "StructLayout" };
			attribute.ArgumentList.Add("LayoutKind.Explicit");
			var structDef = new StructDefinition() { SpecName = "MyStruct" };
			structDef.Attributes.Add(attribute);

			var fieldDef = new FieldDefinition() { SpecName = "FieldName", SpecReturnType = "void" };
			var fieldAttribute = new AttributeDefinition() { SpecName = "FieldOffset" };
			fieldAttribute.ArgumentList.Add("0");
			fieldDef.Attributes.Add(fieldAttribute);
			structDef.Fields.Add(fieldDef);

			var actual = subject.GenerateStruct(output, structDef);

			actual.Should().Be($"[StructLayout(LayoutKind.Explicit)]{NewLine}struct MyStruct{NewLine}{{{NewLine}    [FieldOffset(0)]{NewLine}    void FieldName;{NewLine}}}");
		}

		private ISpawnService MockSpawnService { get; set; }
	}
}
