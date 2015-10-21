using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Collections.Generic;
using Xunit.Extensions;
using System;

using static SixtenLabs.Spawn.Test.OutputStringHelper;

namespace SixtenLabs.Spawn.Test.Extensions
{
  public class SyntaxExtensionsTypeMemberTests
  {
		#region AddProperty

		[Fact]
		public void AddProperty_AddGetterSetter_Correct()
		{
			var subject = NewSubject();

			var definition = new PropertyDefinition("Name", "string");
			definition.AddModifier(SyntaxKind.PublicKeyword);
			definition.AddGetter();
			definition.AddSetter();

			var actual = SyntaxExtensions.AddProperty(definition);

			actual.GetFormattedCode().Should().BeEquivalentTo("public string Name { get; set; }");
		}

		[Fact]
		public void AddProperty_AddGetter_Correct()
		{
			var subject = NewSubject();

			var definition = new PropertyDefinition("Name", "string");
			definition.AddModifier(SyntaxKind.PublicKeyword);
			definition.AddGetter();

			var actual = SyntaxExtensions.AddProperty(definition);

			actual.GetFormattedCode().Should().BeEquivalentTo("public string Name { get; }");
		}

		[Fact]
		public void AddProperty_PrivateGetter_Correct()
		{
			var subject = NewSubject();

			var definition = new PropertyDefinition("Name", "string");
			definition.AddModifier(SyntaxKind.PublicKeyword);
			definition.AddGetter(SyntaxKind.PrivateKeyword);

			var actual = SyntaxExtensions.AddProperty(definition);

			actual.GetFormattedCode().Should().BeEquivalentTo("public string Name { private get; }");
		}

		[Fact]
		public void AddProperty_GetterWithBlock_Correct()
		{
			var subject = NewSubject();

			var definition = new PropertyDefinition("Name", "string");
			definition.AddModifier(SyntaxKind.PublicKeyword);
			definition.AddGetter(SyntaxKind.None, "return name;");

			var actual = SyntaxExtensions.AddProperty(definition);

			var expected = $"public string Name{NL}{OB}{NL}{I4}get{NL}{I4}{OB}{NL}{I8}return name;{NL}{I4}{CB}{NL}{CB}";
      actual.GetFormattedCode().Should().BeEquivalentTo(expected);
		}

		[Fact]
		public void AddProperty_AddAutoReadOnly_Correct()
		{
			var subject = NewSubject();

			var defaultValue = new LiteralDefinition("Bob", typeof(string));
			var definition = new PropertyDefinition("Name", "string", defaultValue);
			definition.AddModifier(SyntaxKind.PublicKeyword);
			definition.AddGetter();

			var actual = SyntaxExtensions.AddProperty(definition);

			actual.GetFormattedCode().Should().BeEquivalentTo("public string Name { get; } = \"Bob\"");
		}

		#endregion

		#region AddField

		[Fact]
    public void AddField_Output_Correct()
    {
      var subject = NewSubject();

      var fieldDefinition = new FieldDefinition("glActiveShaderProgram", "ActiveShaderProgram");
      fieldDefinition.AddModifier(SyntaxKind.InternalKeyword);
      fieldDefinition.AddModifier(SyntaxKind.StaticKeyword);

      var actual = SyntaxExtensions.AddField(fieldDefinition);

      actual.GetFormattedCode().Should().BeEquivalentTo("internal static ActiveShaderProgram glActiveShaderProgram;");
    }

    [Theory]
    [MemberData("DefaultValueData")]
    public void AddField_DefaultValue_Correct(string fieldName, string fieldType, object value, string expected)
    {
      var subject = NewSubject();

      var literalDefinition = new LiteralDefinition(value, value.GetType());
      var fieldDefinition = new FieldDefinition(fieldName, fieldType, literalDefinition);
      fieldDefinition.AddModifier(SyntaxKind.PrivateKeyword);

      var actual = SyntaxExtensions.AddField(fieldDefinition);

      actual.GetFormattedCode().Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> DefaultValueData
    {
      get
      {
        // Or this could read from a file. :)
        return new[]
        {
          new object[] { "isAlive", "bool", true, "private bool isAlive = true;" },
          new object[] { "isAlive", "bool", false, "private bool isAlive = false;" },
          new object[] { "name", "string", "bob", "private string name = \"Bob\";" },
          new object[] { "count", "int", 10, "private int count = 10;" },
          new object[] { "count", "double", 10d, "private double count = 10;" },
          new object[] { "count", "decimal", 10.0m, "private decimal count = 10.0M;" },
          new object[] { "count", "uint", (uint)12, "private uint count = 12U;" },
          new object[] { "count", "byte", (byte)1, "private byte count = 1;" },
          new object[] { "count", "sbyte", (sbyte)1, "private sbyte count = 1;" },
          new object[] { "count", "float", 1.0f, "private float count = 1F;" },
          new object[] { "count", "char", 'c', "private char count = 'c';" },
          new object[] { "count", "long", (long)100, "private long count = 100L;" },
          new object[] { "count", "ulong", (ulong)100, "private ulong count = 100UL;" },
          new object[] { "count", "short", (short)100, "private short count = 100;" },
          new object[] { "count", "ushort", (ushort)100, "private ushort count = 100;" }
        };
      }
    }

		#endregion

		#region Subjects under test

		public CompilationUnitSyntax NewSubject()
    {
      return SF.CompilationUnit();
    }

    #endregion
  }
}
