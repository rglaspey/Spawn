using System.Linq;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn
{
  public static partial class SyntaxExtensions
  {
    #region Public Methods

    public static CompilationUnitSyntax AddClass(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, ClassDefinition classDefinition)
    {
			var memberList = SF.List<MemberDeclarationSyntax>();

			var fields = AddFields(classDefinition.Fields);
			var properties = AddProperties(classDefinition.Properties);

			memberList = memberList.AddRange(fields);
			memberList = memberList.AddRange(properties);		

      var nameSpaceDeclaration = AddNamespace(outputDefinition.Namespace);
      var modifierTokens = GetModifierTokens(classDefinition.ModifierDefinitions);

			var classDeclaration = SF.ClassDeclaration(classDefinition.Name)
        .WithModifiers(modifierTokens)
				.WithMembers(memberList);

      nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(classDeclaration);

      return compilationUnit.AddMembers(nameSpaceDeclaration);
    }

    #endregion
  }
}
