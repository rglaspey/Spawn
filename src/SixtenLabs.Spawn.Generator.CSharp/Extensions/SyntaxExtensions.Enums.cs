using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public static partial class SyntaxExtensions
	{
		private static List<EnumMemberDeclarationSyntax> ComposeEnumMembers(EnumDefinition enumDefinition)
		{
			var enumMembers = new List<EnumMemberDeclarationSyntax>();

			foreach (var enumMember in enumDefinition.Members)
			{
				var enumDeclaration = SF.EnumMemberDeclaration(enumMember.TranslatedName);

				var leadingTrivia = enumMember.Comments.HasComments ? SF.ParseLeadingTrivia(enumMember.Comments.CommentLines.FirstOrDefault()) : SF.TriviaList();
				var literal = SF.Literal(leadingTrivia, enumMember.Value, 0, SF.TriviaList());
				var equalsValueClause = SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, literal));

				enumDeclaration = enumDeclaration.WithEqualsValue(equalsValueClause);

				enumMembers.Add(enumDeclaration);
			}

			return enumMembers;
		}

		public static CompilationUnitSyntax AddEnum(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, EnumDefinition enumDefinition)
		{
			var nameSpaceDeclaration = AddNamespace(outputDefinition.Namespace);

			var members = ComposeEnumMembers(enumDefinition);
			var modifiers = GetModifierTokens(enumDefinition.ModifierDefinitions);

			var enumDeclaration = SF.EnumDeclaration(enumDefinition.TranslatedName)
				.WithModifiers(modifiers)
				.WithMembers(SF.SeparatedList(members));

			if (enumDefinition.BaseType != SyntaxKindDto.None)
			{
				enumDeclaration = enumDeclaration.WithBaseList(SF.BaseList(SF.SingletonSeparatedList<BaseTypeSyntax>(SF.SimpleBaseType(SF.PredefinedType(SF.Token((SyntaxKind)enumDefinition.BaseType))))));
			}

			if (enumDefinition.HasFlags)
			{
				enumDeclaration = enumDeclaration.WithAttributeLists(SF.SingletonList<AttributeListSyntax>(SF.AttributeList(SF.SingletonSeparatedList<AttributeSyntax>(SF.Attribute(SF.IdentifierName("Flags"))))));
			}

			nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(enumDeclaration);

			return compilationUnit.AddMembers(nameSpaceDeclaration);
		}
	}
}
