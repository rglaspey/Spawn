using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn
{
  public static partial class SyntaxExtensions
  {
    #region Private Methods

    private static List<EnumMemberDeclarationSyntax> ComposeEnumMembers(EnumDefinition enumDefinition)
    {
      var enumMembers = new List<EnumMemberDeclarationSyntax>();

      foreach(var enumMember in enumDefinition.MemberNames)
      {
        var enumDeclaration = SF.EnumMemberDeclaration(enumMember);

        if(enumDefinition.MemberValues.Keys.Contains(enumMember))
        {
          enumDeclaration = enumDeclaration.WithEqualsValue(SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(SF.TriviaList(), enumDefinition.MemberValues[enumMember], 0, SF.TriviaList()))));
        }

        enumMembers.Add(enumDeclaration);
      }

      return enumMembers;
    }

    #endregion

    #region Public Methods

    public static CompilationUnitSyntax AddEnum(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, EnumDefinition enumDefinition)
    {
      var nameSpaceDeclaration = AddNamespace(outputDefinition.Namespace);

      var members = ComposeEnumMembers(enumDefinition);
      var modifiers = GetModifierTokens(enumDefinition.ModifierDefinitions);

      var enumDeclaration = SF.EnumDeclaration(enumDefinition.Name)
        .WithModifiers(modifiers)
        .WithMembers(SF.SeparatedList(members));

      if((int)enumDefinition.BaseType != (int)SyntaxKind.None)
      {
        enumDeclaration = enumDeclaration.WithBaseList(SF.BaseList(SF.SingletonSeparatedList<BaseTypeSyntax>(SF.SimpleBaseType(SF.PredefinedType(SF.Token(enumDefinition.BaseType.ConvertToSyntaxKind()))))));
      }

      if(enumDefinition.HasFlags)
      {
        enumDeclaration = enumDeclaration.WithAttributeLists(SF.SingletonList<AttributeListSyntax>(SF.AttributeList(SF.SingletonSeparatedList<AttributeSyntax>(SF.Attribute(SF.IdentifierName("Flags"))))));
      }

      nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(enumDeclaration);

      return compilationUnit.AddMembers(nameSpaceDeclaration);
    }

		public static SyntaxKind ConvertToSyntaxKind(this SyntaxKindX syntaxKind)
		{
			return (SyntaxKind)syntaxKind;
		}

		#endregion
	}
}
