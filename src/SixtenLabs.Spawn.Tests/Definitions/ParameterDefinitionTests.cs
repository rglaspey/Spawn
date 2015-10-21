using Xunit;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
  public class ParameterDefinitionTests
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


    #region Subjects under test

    private ParameterDefinition NewSubject(string name, string returnType)
    {
      return new ParameterDefinition(name, returnType);
    }

    #endregion
  }
}
