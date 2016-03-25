using Microsoft.CodeAnalysis.CSharp.Syntax;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn
{
	public static partial class SyntaxExtensions
	{
		public static CompilationUnitSyntax AddStruct(this CompilationUnitSyntax compilationUnit, OutputDefinition outputDefinition, StructDefinition structDefinition)
		{
			var memberList = SF.List<MemberDeclarationSyntax>();

			var fields = AddFields(structDefinition.FieldDefinitions);
			var properties = AddProperties(structDefinition.PropertyDefinitions);

			memberList = memberList.AddRange(fields);
			memberList = memberList.AddRange(properties);

			var nameSpaceDeclaration = AddNamespace(outputDefinition.Namespace);
			var modifierTokens = GetModifierTokens(structDefinition.ModifierDefinitions);

			var classDeclaration = SF.StructDeclaration(structDefinition.Name)
				.WithModifiers(modifierTokens)
				.WithMembers(memberList);

			nameSpaceDeclaration = nameSpaceDeclaration.AddMembers(classDeclaration);

			return compilationUnit.AddMembers(nameSpaceDeclaration);
		}
	}
}
