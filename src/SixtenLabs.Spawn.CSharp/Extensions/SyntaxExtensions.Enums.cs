﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.Linq;
using System;

namespace SixtenLabs.Spawn.CSharp
{
	public static partial class SyntaxExtensions
	{
		private static List<EnumMemberDeclarationSyntax> ComposeEnumMembers(EnumDefinition enumDefinition)
		{
			var enumMembers = new List<EnumMemberDeclarationSyntax>();

			foreach (var enumMember in enumDefinition.Members)
			{
				var enumDeclaration = SF.EnumMemberDeclaration(enumMember.TranslatedName);

				var leadingTrivia = enumMember.Comments.HasComments ? enumMember.Comments.GetComments() : SF.TriviaList();
				var literal = SF.Literal(SF.TriviaList(), enumMember.Value, 0, SF.TriviaList());
				var equalsValueClause = SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, literal));

				enumDeclaration = enumDeclaration.WithLeadingTrivia(leadingTrivia).WithEqualsValue(equalsValueClause);

				enumMembers.Add(enumDeclaration);
			}

			return enumMembers;
		}

		public static CompilationUnitSyntax AddEnum(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, EnumDefinition enumDefinition)
		{
			if(string.IsNullOrEmpty(enumDefinition.SpecName))
			{
				throw new ArgumentNullException("Enum must at least have a valid SpecName property set.");
			}

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

			if (nameSpaceDeclaration != null)
			{
				nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(enumDeclaration);

				return compilationUnit.AddMembers(nameSpaceDeclaration);
			}
			else
			{
				return compilationUnit.AddMembers(enumDeclaration);
			}
		}
	}
}
