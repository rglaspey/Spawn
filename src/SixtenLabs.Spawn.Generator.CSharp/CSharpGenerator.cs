using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public class CSharpGenerator : CodeGenerator
	{
		public CSharpGenerator(ISpawnService spawn, IXmlSerializer serializer)
			: base(spawn, serializer)
		{
		}

		/// <summary>
		/// Generate a single output with a class
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="classDefinition"></param>
		/// <returns></returns>
		public string GenerateClass(OutputDefinition outputDefinition, ClassDefinition classDefinition)
		{
			var code = SF.CompilationUnit()

				.AddUsingDirectives(outputDefinition.Usings)
				.AddClass(outputDefinition, classDefinition)
				.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken))
				.NormalizeWhitespace();

			var contents = code.GetFormattedCode();
			AddToProject(outputDefinition, contents);

			return contents;
		}

		/// <summary>
		/// Generate a single output with a class
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="structDefinition"></param>
		/// <returns></returns>
		public string GenerateStruct(OutputDefinition outputDefinition, StructDefinition structDefinition)
		{
			var code = SF.CompilationUnit()

				.AddUsingDirectives(outputDefinition.Usings)
				.AddStruct(outputDefinition, structDefinition)
				.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken))
				.NormalizeWhitespace();

			var contents = code.GetFormattedCode();
			AddToProject(outputDefinition, contents);

			return contents;
		}

		/// <summary>
		/// Generate a single output with an enum
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="enumDefinition"></param>
		/// <returns></returns>
		public string GenerateEnum(OutputDefinition outputDefinition, EnumDefinition enumDefinition)
		{
			var code = SF.CompilationUnit()
				.AddUsingDirectives(outputDefinition.Usings)
				.AddEnum(outputDefinition, enumDefinition)
				.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken))
				.NormalizeWhitespace();

			var contents = code.GetFormattedCode();
			AddToProject(outputDefinition, contents);

			return contents;
		}
	}
}
