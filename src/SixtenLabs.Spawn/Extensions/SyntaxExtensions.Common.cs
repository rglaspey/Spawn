using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.Formatting;

namespace SixtenLabs.Spawn
{
  public static partial class SyntaxExtensions
  {
		#region Block Syntax

		/// <summary>
		/// Currently support statements defined completely by the user.
		/// 
		/// TODO : Explore support all the different statement syntaxes (a lot of work not sure it brings any value at this point).
		/// 
		/// </summary>
		/// <param name="definition"></param>
		/// <returns></returns>
		private static BlockSyntax CreateBlock(BlockDefinition definition)
		{
			var statementList = new List<StatementSyntax>();

			foreach (var statement in definition.Statements)
			{
				var declaration = SF.ParseStatement(statement.Code);
				statementList.Add(declaration);
			}

			return SF.Block(statementList);
		}

		#endregion

		#region Literal Expression

		private static LiteralExpressionSyntax GetLiteralExpression(LiteralDefinition literalDefinition)
		{
			LiteralExpressionSyntax expression = null;

			if (literalDefinition.LiteralType == typeof(string))
			{
				expression = SF.LiteralExpression(SyntaxKind.StringLiteralExpression, SF.Literal(Convert.ToString(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(bool))
			{
				bool value = Convert.ToBoolean(literalDefinition.Value);
				var valueToken = value ? SF.Token(SyntaxKind.TrueKeyword) : SF.Token(SyntaxKind.FalseKeyword);
				expression = SF.LiteralExpression(value ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression).WithToken(valueToken);
			}
			else if (literalDefinition.LiteralType == typeof(int))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToInt32(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(double))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToDouble(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(decimal))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToDecimal(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(uint))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToUInt32(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(byte))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToByte(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(sbyte))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToSByte(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(float))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToSingle(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(char))
			{
				expression = SF.LiteralExpression(SyntaxKind.StringLiteralExpression, SF.Literal(Convert.ToChar(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(long))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToInt64(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(ulong))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToUInt64(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(short))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToInt16(literalDefinition.Value)));
			}
			else if (literalDefinition.LiteralType == typeof(ushort))
			{
				expression = SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(Convert.ToUInt16(literalDefinition.Value)));
			}

			return expression;
		}

		#endregion

		#region Using Directive Methods

		private static UsingDirectiveSyntax StandardUsing(string dllName)
		{
			return SF.UsingDirective(SF.IdentifierName(dllName)).WithUsingKeyword(SF.Token(SyntaxKind.UsingKeyword)).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
		}

		private static UsingDirectiveSyntax StaticUsing(string dllName)
		{
			return SF.UsingDirective(SF.IdentifierName(dllName)).WithUsingKeyword(SF.Token(SyntaxKind.UsingKeyword)).WithStaticKeyword(SF.Token(SyntaxKind.StaticKeyword)).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
		}

		private static UsingDirectiveSyntax AliasUsing(string dllName, string alias)
		{
			var aliasNameEqualsSyntax = SF.NameEquals(SF.IdentifierName(alias));
			return SF.UsingDirective(SF.IdentifierName(dllName)).WithUsingKeyword(SF.Token(SyntaxKind.UsingKeyword)).WithAlias(aliasNameEqualsSyntax).WithSemicolonToken(SF.Token(SyntaxKind.SemicolonToken));
		}

		/// <summary>
		/// This will create a sinlge using statement syntax.
		/// 
		/// Example:
		///   using System; -> from System
		///   using System.Linq; -> from System.Linq
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private static UsingDirectiveSyntax ComposeUsing(UsingDirectiveDefinition usingDefinition)
    {
      if(usingDefinition.IsStatic)
			{
				return StaticUsing(usingDefinition.Name);
			}
			else if(usingDefinition.UseAlias)
			{
				return AliasUsing(usingDefinition.Name, usingDefinition.Alias);
			}
			else
			{
				return StandardUsing(usingDefinition.Name);
			}
    }

		/// <summary>
		/// Adds using statements to the syntax in the compliation unit (represents the final file)
		/// </summary>
		/// <param name="compilationUnit">The compliation unit to update</param>
		/// <param name="usings">a list of usings to create using statements with</param>
		/// <returns>the updated compilation unit</returns>
		public static CompilationUnitSyntax AddUsingDirectives(this CompilationUnitSyntax compilationUnit, IList<UsingDirectiveDefinition> usingDefinitions)
		{
			if (usingDefinitions != null && usingDefinitions.Count > 0)
			{
				var usingList = new List<UsingDirectiveSyntax>();

				foreach (var usingDefinition in usingDefinitions)
				{
					var directive = ComposeUsing(usingDefinition);

					if (directive != null)
					{
						usingList.Add(directive);
					}
				}

				return compilationUnit.WithUsings(SF.List(usingList));
			}
			else
			{
				return compilationUnit;
			}
		}

		#endregion

		#region Modifier Methods

		private static SyntaxTokenList GetModifierTokens(IList<ModifierDefinition> modifierDefinitions)
    {
      var list = new List<SyntaxToken>();

      foreach(var modifier in modifierDefinitions)
      {
        list.Add(SF.Token(modifier.Modifier.ConvertToSyntaxKind()));
      }

      return SF.TokenList(list);
    }

		#endregion

		#region Namespace Methods

		public static NamespaceDeclarationSyntax AddNamespace(NamespaceDefinition @namespace)
    {
      return SF.NamespaceDeclaration(SF.IdentifierName(@namespace.Name));
    }

		#endregion

		#region Formatting Methods

		public static string GetFormattedCode(this SyntaxNode code)
		{
			var cw = new AdhocWorkspace();
			cw.Options.WithChangedOption(CSharpFormattingOptions.IndentBraces, true);
			var formattedCode = Formatter.Format(code, cw);

			return formattedCode.ToFullString();
		}

		#endregion
	}
}
