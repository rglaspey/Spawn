using System;
using System.Linq;

using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
  public class EnumDefinitionTests
  {
    private EnumDefinition NewSubject(string name)
    {
      return new EnumDefinition(name);
    }

    [Fact]
    public void AddEnumMember_MemberNameNull_ThrowsException()
    {
      var subject = NewSubject("Batman");

      Action act = () => subject.AddEnumMember(string.Empty, string.Empty);

      act.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: The member name must be defined");
    }

    [Fact]
    public void AddEnumMember_Constructor_BaseTypeIsInt()
    {
      var subject = NewSubject("Batman");

      subject.BaseType.Should().Be(SyntaxKind.IntKeyword);
    }

    [Fact]
    public void AddEnumMember_Constructor_HasFlagsFalse()
    {
      var subject = NewSubject("Batman");

      subject.HasFlags.Should().BeFalse();
    }

    [Fact]
    public void AddEnumMember_MemberName_MemberNamesCorrectCount()
    {
      var subject = NewSubject("Batman");

      subject.AddEnumMember("Batmobile", string.Empty, string.Empty);

      subject.MemberNames.Count().Should().Be(1);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(null, 0)]
    [InlineData("I am a comment", 1)]
    public void AddEnumMember_WithComment_MemberCommentsCorrectCount(string comment, int expected)
    {
      var subject = NewSubject("Batman");

      subject.AddEnumMember("Batmobile", string.Empty, comment);

      subject.MemberComments.Count().Should().Be(expected);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(null, 0)]
    [InlineData("1", 1)]
    public void AddEnumMember_WithValue_MemberValuesCorrectCount(string value, int expected)
    {
      var subject = NewSubject("Batman");

      subject.AddEnumMember("Batmobile", value, null);

      subject.MemberValues.Count().Should().Be(expected);
    }
  }
}
