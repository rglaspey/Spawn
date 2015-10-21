using Xunit;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Test.Definitions
{
	public class StructDefinitionTests
	{
		[Fact]
		public void Constructor_Name_IsSet()
		{
			var subject = NewSubject("Batman");

			subject.Name.Should().Be("Batman");
		}

		[Fact]
		public void AddField_FieldDefinitions_CountIsCorrect()
		{
			var subject = NewSubject("Batman");

			subject.AddField("count");

			subject.FieldDefinitions.Count.Should().Be(1);
		}

		[Fact]
		public void AddField_WithDefaultValue_ValueIsCorrect()
		{
			var subject = NewSubject("Batman");

			subject.AddField("count", "int", 10);

			subject.FieldDefinitions[0].DefaultValue.Value.Should().Be(10);
		}

		[Fact]
		public void AddModifier_ModifierDefinitions_CountIsCorrect()
		{
			var subject = NewSubject("Batman");

			subject.AddModifier(SyntaxKindX.PublicKeyword);

			subject.ModifierDefinitions.Count.Should().Be(1);
		}

		#region Subjects under test

		private StructDefinition NewSubject(string name)
		{
			return new StructDefinition(name);
		}

		#endregion
	}
}
