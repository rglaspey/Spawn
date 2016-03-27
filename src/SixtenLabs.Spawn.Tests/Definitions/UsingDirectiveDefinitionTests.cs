using System;

using Xunit;
using FluentAssertions;

namespace SixtenLabs.Spawn.Test.Definitions
{
	//public class UsingDirectiveDefinitionTests
	//{
	//	#region Alias Constructor

	//	[Theory]
	//	[InlineData(null)]
	//	[InlineData("")]
	//	public void Constructor_Alias_ThrowsException(string alias)
	//	{
	//		Action act = () => NewSubjectAlias("PC.MyCompany.Project", alias);

	//		act.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: You cannot have a null or empty alias. Pass in correct alias value or use the non alias constructor.");
	//	}

	//	[Fact]
	//	public void ConstructorAlias_Alias_IsCorrect()
	//	{
	//		var subject = NewSubjectAlias("PC.MyCompany.Project", "Project");

	//		subject.Alias.Should().Be("Project");
	//	}

	//	[Fact]
	//	public void ConstructorAlias_UseAlias_True()
	//	{
	//		var subject = NewSubjectAlias("PC.MyCompany.Project", "Project");

	//		subject.UseAlias.Should().BeTrue();
	//	}

	//	[Fact]
	//	public void ConstructorAlias_IsStatic_False()
	//	{
	//		var subject = NewSubjectAlias("PC.MyCompany.Project", "Project");

	//		subject.IsStatic.Should().BeFalse();
	//	}

	//	[Fact]
	//	public void ConstructorAlias_Name_IsCorrect()
	//	{
	//		var subject = NewSubjectAlias("PC.MyCompany.Project", "Project");

	//		subject.Name.Should().Be("PC.MyCompany.Project");
	//	}

	//	#endregion

	//	#region Static Constructor

	//	[Fact]
	//	public void ConstructorStatic_Name_IsCorrect()
	//	{
	//		var subject = NewSubject("System", true);

	//		subject.Name.Should().Be("System");
	//	}

	//	[Fact]
	//	public void ConstructorStatic_IsStatic_True()
	//	{
	//		var subject = NewSubject("System.Math", true);

	//		subject.IsStatic.Should().BeTrue();
	//	}

	//	[Fact]
	//	public void ConstructorStatic_UseAlias_False()
	//	{
	//		var subject = NewSubject("System.Math", true);

	//		subject.UseAlias.Should().BeFalse();
	//	}

	//	[Fact]
	//	public void ConstructorStatic_Alias_Null()
	//	{
	//		var subject = NewSubject("System.Math", true);

	//		subject.Alias.Should().BeNull();
	//	}

	//	#endregion

	//	#region Standard Constructor

	//	[Fact]
	//	public void ConstructorStandard_Name_IsCorrect()
	//	{
	//		var subject = NewSubject("System", false);

	//		subject.Name.Should().Be("System");
	//	}

	//	[Fact]
	//	public void ConstructorStandard_IsStatic_False()
	//	{
	//		var subject = NewSubject("System", false);

	//		subject.IsStatic.Should().BeFalse();
	//	}

	//	[Fact]
	//	public void ConstructorStandard_UseAlias_False()
	//	{
	//		var subject = NewSubject("System", false);

	//		subject.UseAlias.Should().BeFalse();
	//	}

	//	[Fact]
	//	public void ConstructorStandard_Alias_Null()
	//	{
	//		var subject = NewSubject("System", false);

	//		subject.Alias.Should().BeNull();
	//	}

	//	#endregion

	//	#region Subjects Under Tests

	//	private UsingDirectiveDefinition NewSubject(string name, bool isStatic)
	//	{
	//		return new UsingDirectiveDefinition(name, isStatic);
	//	}

	//	private UsingDirectiveDefinition NewSubjectAlias(string name, string alias)
	//	{
	//		return new UsingDirectiveDefinition(name, alias);
	//	}

	//	#endregion
	//}
}
