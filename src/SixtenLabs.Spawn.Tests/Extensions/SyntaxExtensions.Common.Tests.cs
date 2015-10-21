using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn.Test.Extensions
{
	public class SyntaxExtensionsCommonTests
	{
		#region AddUsingDirectives

		[Fact]
		public void AddUsingDirectives_Standard_Correct()
		{
			var subject = NewSubject();

			var usingDirectiveDefinition = new UsingDirectiveDefinition("System.Text");

			var actual = subject.AddUsingDirectives(new[] { usingDirectiveDefinition });

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			actualString.Should().Be("using System.Text;");
		}

		[Fact]
		public void AddUsingDirectives_Static_Correct()
		{
			var subject = NewSubject();

			var usingDirectiveDefinition = new UsingDirectiveDefinition("System.Math", true);

			var actual = subject.AddUsingDirectives(new[] { usingDirectiveDefinition });

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			actualString.Should().Be("using static System.Math;");
		}

		[Fact]
		public void AddUsingDirectives_Alias_Correct()
		{
			var subject = NewSubject();

			var usingDirectiveDefinition = new UsingDirectiveDefinition("PC.MyCompany.Project", "Project");

			var actual = subject.AddUsingDirectives(new[] { usingDirectiveDefinition });

			var actualString = actual.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken)).NormalizeWhitespace().GetFormattedCode();

			actualString.Should().Be("using Project = PC.MyCompany.Project;");
		}

		#endregion

		#region AddNamespace

		[Fact]
		public void AddNamespace_NamespaceOutput_IsCorrect()
		{
			var subject = NewSubject();

			var namespaceDefinition = new NamespaceDefinition("PC.MyCompany.Project");

			var actual = SyntaxExtensions.AddNamespace(namespaceDefinition);

			var actualString = actual.GetFormattedCode();

			actualString.Should().BeEquivalentTo("namespace PC.MyCompany.Project\r\n{\r\n}");
		}

		#endregion

		#region GetModifierTokens

		[Fact]
		public void GetModifierTokens_NamespaceOutput_IsCorrect()
		{
			var subject = NewSubject();

			var namespaceDefinition = new NamespaceDefinition("PC.MyCompany.Project");

			var actual = SyntaxExtensions.AddNamespace(namespaceDefinition);

			var actualString = actual.GetFormattedCode();

			actualString.Should().BeEquivalentTo("namespace PC.MyCompany.Project\r\n{\r\n}");
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
