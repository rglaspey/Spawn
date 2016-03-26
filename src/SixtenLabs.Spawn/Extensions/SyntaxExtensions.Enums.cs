using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

using System.Linq;
using Microsoft.CodeAnalysis;

namespace SixtenLabs.Spawn
{
  public static partial class SyntaxExtensions
  {
    private static List<EnumMemberDeclarationSyntax> ComposeEnumMembers(EnumDefinition enumDefinition)
    {
      var enumMembers = new List<EnumMemberDeclarationSyntax>();

      foreach(var enumMember in enumDefinition.MemberNames)
      {
				var hasComments = enumDefinition.MemberComments.ContainsKey(enumMember);

				EnumMemberDeclarationSyntax enumDeclaration = null;

				//if (hasComments)
				//{
				//	var comment = enumDefinition.MemberComments[enumMember];

				//	var body = SF.Literal(enumMember);
				//	var leading = SF.TriviaList().Add(SF.Comment($"// {comment}"));
				//	var trailing = SF.TriviaList();
				//	var identifier = SF.Token(leading, SyntaxKind.token,  "", enumMember, trailing);
					
				//	enumDeclaration = SF.EnumMemberDeclaration(identifier);
				//}
				//else
				//{
					enumDeclaration = SF.EnumMemberDeclaration(enumMember);
				//}

        if(enumDefinition.MemberValues.Keys.Contains(enumMember))
        {
					enumDeclaration = enumDeclaration.WithEqualsValue(SF.EqualsValueClause(SF.LiteralExpression(SyntaxKind.NumericLiteralExpression, SF.Literal(SF.TriviaList(), enumDefinition.MemberValues[enumMember], 0, SF.TriviaList()))));
        }

        enumMembers.Add(enumDeclaration);
      }

      return enumMembers;
    }

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
        enumDeclaration = enumDeclaration.WithAttributeLists(SF.SingletonList(SF.AttributeList(SF.SingletonSeparatedList(SF.Attribute(SF.IdentifierName("Flags"))))));
      }

			if(enumDefinition.MemberComments.Count > 0)
			{
				var trivia = SF.TriviaList();

				foreach (var comment in enumDefinition.MemberComments.Values)
				{
					trivia.Add(SF.SyntaxTrivia(SyntaxKind.SingleLineCommentTrivia, comment));
				}

				enumDeclaration.WithLeadingTrivia(trivia);
			}

      nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(enumDeclaration);

      return compilationUnit.AddMembers(nameSpaceDeclaration);
    }

		public static SyntaxKind ConvertToSyntaxKind(this SyntaxKindX syntaxKind)
		{
			return (SyntaxKind)syntaxKind;
		}
	}
}
