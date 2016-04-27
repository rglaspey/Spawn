﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public static partial class SyntaxExtensions
	{
		private static EqualsValueClauseSyntax GetInitializer(LiteralDefinition literalDefinition)
		{
			EqualsValueClauseSyntax equalsSyntax = null;

			if (literalDefinition != null)
			{
				var expression = GetLiteralExpression(literalDefinition);
				equalsSyntax = SF.EqualsValueClause(expression);
			}

			return equalsSyntax;
		}

		public static FieldDeclarationSyntax AddField(FieldDefinition fieldDefinition)
		{
			var modifiers = GetModifierTokens(fieldDefinition.ModifierDefinitions);
			var returnType = SF.VariableDeclaration(SF.IdentifierName(fieldDefinition.TranslatedReturnType));
			var fieldName = SF.VariableDeclarator(SF.Identifier(fieldDefinition.TranslatedName));
			var initializer = GetInitializer(fieldDefinition.DefaultValue);

			fieldName = fieldName.WithInitializer(initializer);

			var fieldDeclaration = SF.FieldDeclaration(returnType
				.AddVariables(fieldName))
				.WithModifiers(modifiers);

			return fieldDeclaration;
		}

		public static IList<FieldDeclarationSyntax> AddFields(IList<FieldDefinition> fieldDefinitions)
		{
			var list = new List<FieldDeclarationSyntax>();

			foreach (var fieldDefinition in fieldDefinitions)
			{
				var fieldDeclarationSyntax = AddField(fieldDefinition);
				list.Add(fieldDeclarationSyntax);
			}

			return list;
		}

		private static AccessorDeclarationSyntax ComposeAccessor(AccessorDefinition definition)
		{
			var declaration = SF.AccessorDeclaration(definition.AccessorType);

			if (definition.Modifier != SyntaxKind.None)
			{
				declaration = declaration.WithModifiers(SF.TokenList(SF.Token(definition.Modifier)));
			}

			if (definition.Block != null)
			{
				var block = CreateBlock(definition.Block);
				declaration = declaration.WithBody(block);
			}
			else
			{
				declaration = declaration
				.WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
			}

			return declaration;
		}

		private static AccessorListSyntax GetAccessors(AccessorDefinition getter, AccessorDefinition setter)
		{
			var accessorList = SF.AccessorList();

			if (getter != null)
			{
				accessorList = accessorList.AddAccessors(ComposeAccessor(getter));
			}

			if (setter != null)
			{
				accessorList = accessorList.AddAccessors(ComposeAccessor(setter));
			}

			return accessorList;
		}

		public static PropertyDeclarationSyntax AddProperty(PropertyDefinition propertyDefinition)
		{
			var modifiers = GetModifierTokens(propertyDefinition.ModifierDefinitions);
			var returnType = SF.ParseTypeName(propertyDefinition.TranslatedReturnType);
			var accessors = GetAccessors(propertyDefinition.Getter, propertyDefinition.Setter);
			var initializer = GetInitializer(propertyDefinition.DefaultValue);

			var declaration = SF.PropertyDeclaration(returnType, SF.Identifier(propertyDefinition.TranslatedName))
				.WithModifiers(modifiers)
				.WithAccessorList(accessors)
				.WithInitializer(initializer);

			return declaration;
		}

		public static IList<PropertyDeclarationSyntax> AddProperties(IList<PropertyDefinition> definitions)
		{
			var list = new List<PropertyDeclarationSyntax>();

			foreach (var property in definitions)
			{
				var propertySyntax = AddProperty(property);
				list.Add(propertySyntax);
			}

			return list;
		}
	}
}