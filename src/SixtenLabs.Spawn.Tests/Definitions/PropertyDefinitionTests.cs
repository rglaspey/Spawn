using Xunit;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
  public class PropertyDefinitionTests
  {
    [Fact]
    public void Constructor_Name_IsSet()
    {
      var subject = NewSubject("Name", "void");

      subject.Name.Should().Be("Name");
    }

    [Fact]
    public void Constructor_ReturnType_IsSet()
    {
      var subject = NewSubject("Name", "void");

      subject.ReturnType.Should().Be("void");
    }

    [Fact]
    public void Constructor_DefaultValue_IsNull()
    {
      var subject = NewSubject("Name", "void");

      subject.DefaultValue.Should().BeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("Santa")]
    public void Constructor_DefaultValue_IsSet(string defaultValue)
    {
      var subject = NewSubject("Name", "void", defaultValue);

      subject.DefaultValue.Value.Should().Be(defaultValue);
    }

    [Fact]
    public void AddParameter_Parameters_CorrectCount()
    {
      var subject = NewSubject("Name", "void");

      subject.AddParameter("name", "string");

      subject.Parameters.Count.Should().Be(1);
    }

    [Fact]
    public void AddModifier_Modifiers_CorrectCount()
    {
      var subject = NewSubject("Name", "void");

      subject.AddModifier(SyntaxKind.PublicKeyword);

      subject.ModifierDefinitions.Count.Should().Be(1);
    }

    #region Subjects under test

    private PropertyDefinition NewSubject(string name, string returnType, string defaultValue = null)
    {
      LiteralDefinition literalDefinition = null;

      if(defaultValue != null)
      {
        literalDefinition = new LiteralDefinition(defaultValue, defaultValue.GetType());
      }

      return new PropertyDefinition(name, returnType, literalDefinition);
    }

    #endregion
  }
}
