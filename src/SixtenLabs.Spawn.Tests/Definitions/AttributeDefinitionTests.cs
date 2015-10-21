using Xunit;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
  public class AttributeDefinitionTests
  {
    [Fact]
    public void Constructor_Name_IsSet()
    {
      var subject = NewSubject("Name");

      subject.Name.Should().Be("Name");
    }

    #region Subjects under test

    private AttributeDefinition NewSubject(string name)
    {
      return new AttributeDefinition(name);
    }

    #endregion
  }
}
