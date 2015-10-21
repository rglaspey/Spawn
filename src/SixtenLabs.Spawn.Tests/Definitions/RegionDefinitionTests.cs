using Xunit;
using FluentAssertions;

namespace SixtenLabs.Spawn.Test.Definitions
{
  public class RegionDefinitionTests
  {
    [Fact]
    public void Constructor_Name_IsSet()
    {
      var subject = NewSubject("Name", false);

      subject.Name.Should().Be("Name");
    }

    [Fact]
    public void Constructor_UseRegionDirective_False()
    {
      var subject = NewSubject("Name", false);

      subject.UseRegionDirective.Should().BeFalse();
    }

    [Fact]
    public void Constructor_UseRegionDirective_True()
    {
      var subject = NewSubject("Name", true);

      subject.UseRegionDirective.Should().BeTrue();
    }

    #region Subjects under test

    private RegionDefinition NewSubject(string name, bool useRegionDirective)
    {
      return new RegionDefinition(name, useRegionDirective);
    }

    #endregion
  }
}
