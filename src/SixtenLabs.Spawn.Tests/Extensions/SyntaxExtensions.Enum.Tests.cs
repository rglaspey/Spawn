using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

using static SixtenLabs.Spawn.Test.OutputStringHelper;

namespace SixtenLabs.Spawn.Test.Extensions
{
	public class SyntaxExtensionsEnumTests
	{
		#region AddEnum

		[Fact]
		public void AddEnum_Output_Correct()
		{
			var output = new OutputDefinition("OnMyToast.cs");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new EnumDefinition("OnMyToast");
			definition.AddModifier(SyntaxKind.PublicKeyword);

			definition.AddEnumMember("Error", "0");
			definition.AddEnumMember("Butter", "");
			definition.AddEnumMember("Eggs", "2");
			definition.AddEnumMember("Jam", "4");

			var subject = NewSubject();

			var actual = subject.AddEnum(output, definition);

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			var expected = $"namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}public enum OnMyToast : int{NL}{I4}{OB}{NL}{I8}Error = 0,{NL}{I8}Butter,{NL}{I8}Eggs = 2,{NL}{I8}Jam = 4{NL}{I4}{CB}{NL}{CB}";
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
