using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
	public class MethodDefinitionTests
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
    public void AddParameter_Parameters_CorrectCount()
    {
      var subject = NewSubject("Name", "void");

      subject.AddParameter("name", "string");

      subject.Parameters.Count.Should().Be(1);
    }

    [Fact]
    public void HasParameters_NoParameters_False()
    {
      var subject = NewSubject("Name", "void");

      subject.HasParameters.Should().BeFalse();
    }

    [Fact]
    public void HasParameters_Parameters_True()
    {
      var subject = NewSubject("Name", "void");

      subject.AddParameter("name", "string");

      subject.HasParameters.Should().BeTrue();
    }

    [Fact]
    public void AddModifier_Modifiers_CorrectCount()
    {
      var subject = NewSubject("Name", "void");

      subject.AddModifier(SyntaxKind.PublicKeyword);

      subject.ModifierDefinitions.Count.Should().Be(1);
    }

    [Fact]
    public void AddBody_Body_NotNull()
    {
      var subject = NewSubject("Name", "void");

      subject.AddCodeLineToBody("count++");

      subject.Block.Should().NotBeNull();
    }

    [Fact]
    public void AddBody_BodyLines_CorrectCount()
    {
      var subject = NewSubject("Name", "void");

      subject.AddCodeLineToBody("count++");

      subject.Block.Statements.Count.Should().Be(1);
    }

    [Fact]
    public void HasBody_NoBody_False()
    {
      var subject = NewSubject("Name", "void");

      subject.HasBlock.Should().BeFalse();
    }

    [Fact]
    public void HasBody_BodyLinesAdded_True()
    {
      var subject = NewSubject("Name", "void");

      subject.AddCodeLineToBody("count++");

      subject.HasBlock.Should().BeTrue();
    }

    #region Subjects under test

    private MethodDefinition NewSubject(string name, string returnType, string defaultValue = null)
		{
			return new MethodDefinition(name, returnType);
		}

		#endregion
	}
}
