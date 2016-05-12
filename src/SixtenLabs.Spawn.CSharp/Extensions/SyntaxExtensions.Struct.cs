using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn.CSharp
{
	public static partial class SyntaxExtensions
	{
		public static CompilationUnitSyntax AddStruct(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, StructDefinition structDefinition)
		{
			var memberList = SF.List<MemberDeclarationSyntax>();

			var fields = AddFields(structDefinition.Fields);
			//var properties = AddProperties(structDefinition.Properties);

			memberList = memberList.AddRange(fields);
			//memberList = memberList.AddRange(properties);

			var nameSpaceDeclaration = AddNamespace(outputDefinition.Namespace);
			var modifierTokens = GetModifierTokens(structDefinition.ModifierDefinitions);

			if(structDefinition.Comments.HasComments)
			{
				var comments = structDefinition.Comments.GetComments();
				modifierTokens.Insert(0, SF.Token(comments, SyntaxKind.XmlTextLiteralToken, SF.TriviaList()));
			}

			var structDeclaration = SF.StructDeclaration(structDefinition.TranslatedName)
				.WithModifiers(modifierTokens)
				.WithMembers(memberList);

			nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(structDeclaration);

			return compilationUnit.AddMembers(nameSpaceDeclaration);
		}
	}
}
