using Xunit;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
	public class InterfaceDefinitionTests
	{
		[Fact]
		public void Constructor_Name_IsSet()
		{
			var subject = NewSubject("Batman");

			subject.Name.Should().Be("Batman");
		}

		[Fact]
		public void AddModifier_ModifierDefinitions_CountIsCorrect()
		{
			var subject = NewSubject("Batman");

			subject.AddModifier(SyntaxKind.PublicKeyword);

			subject.ModifierDefinitions.Count.Should().Be(1);
		}

		#region Subjects under test

		private InterfaceDefinition NewSubject(string name)
		{
			return new InterfaceDefinition(name);
		}

		#endregion
	}
}
