using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

using static SixtenLabs.Spawn.Test.OutputStringHelper;

namespace SixtenLabs.Spawn.Test.Extensions
{
	public class SyntaxExtensionsClassTests
	{
		#region AddClass

		[Fact]
		public void AddClass_X_Correct()
		{
			var output = new OutputDefinition("Delegates.cs");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new ClassDefinition("Delegates");

			definition.AddModifier(SyntaxKindX.InternalKeyword);
			definition.AddModifier(SyntaxKindX.StaticKeyword);
			definition.AddModifier(SyntaxKindX.PartialKeyword);

			var subject = NewSubject();
			
			var actual = subject.AddClass(output, definition);

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			var expected = $"namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}internal static partial class Delegates{NL}{I4}{OB}{NL}{I4}{CB}{NL}{CB}";
			actualString.Should().Be(expected);
		}

    [Fact]
    public void AddClass_WithField_Correct()
    {
      var output = new OutputDefinition("Delegates.cs");
      output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

      var definition = new ClassDefinition("Delegates");

      definition.AddModifier(SyntaxKindX.InternalKeyword);
      definition.AddModifier(SyntaxKindX.StaticKeyword);
      definition.AddModifier(SyntaxKindX.PartialKeyword);

      definition.AddField("count", "int");

      var subject = NewSubject();

      var actual = subject.AddClass(output, definition);

      var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			var expected = $"namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}internal static partial class Delegates{NL}{I4}{OB}{NL}{I8}int count;{NL}{I4}{CB}{NL}{CB}";
			actualString.Should().Be(expected);
    }

		[Fact]
		public void AddClass_WithProperty_Correct()
		{
			var output = new OutputDefinition("Delegates.cs");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new ClassDefinition("Customer");

			definition.AddModifier(SyntaxKindX.PublicKeyword);

			var property = definition.AddProperty("Name", "string");
			property.AddModifier(SyntaxKindX.PublicKeyword);
			property.AddGetter();
			property.AddSetter();

			var subject = NewSubject();

			var actual = subject.AddClass(output, definition);

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			var expected = $"namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}public class Customer{NL}{I4}{OB}{NL}{I8}public string Name{NL}{I8}{OB}{NL}{I12}get;{NL}{I12}set;{NL}{I8}{CB}{NL}{I4}{CB}{NL}{CB}";
			actualString.Should().Be(expected);
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
