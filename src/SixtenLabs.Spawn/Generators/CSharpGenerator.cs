using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn
{
	public class CSharpGenerator : CodeGenerator
	{
		public CSharpGenerator()
		{
		}

		/// <summary>
		/// Generate a single output with an enum
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="enumDefinition"></param>
		/// <returns></returns>
		public override string GenerateEnum(OutputDefinition outputDefinition, EnumDefinition enumDefinition)
		{
			var code = SF.CompilationUnit()
				.AddUsingDirectives(outputDefinition.Usings)
				.AddEnum(outputDefinition, enumDefinition)
				.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken))
				.NormalizeWhitespace();

			var formattedCode = code.GetFormattedCode();

			return formattedCode;
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

			return code.GetFormattedCode();
		}

		/// <summary>
		/// Generate a single output with a struct
		/// </summary>
		/// <param name="outputDefinition"></param>
		/// <param name="delegateDefinition"></param>
		/// <returns></returns>
		public string GenerateStruct(OutputDefinition outputDefinition, StructDefinition structDefinition)
		{
			var code = SF.CompilationUnit()
				.AddUsingDirectives(outputDefinition.Usings)
				.AddStruct(outputDefinition, structDefinition)
				.WithEndOfFileToken(SF.Token(SyntaxKind.EndOfFileToken))
				.NormalizeWhitespace();

			return code.GetFormattedCode();
		}

		///// <summary>
		///// Generate a single output with an interface
		///// </summary>
		///// <param name="outputDefinition"></param>
		///// <param name="delegateDefinition"></param>
		///// <returns></returns>
		//public string GenerateInterface(OutputDefinition outputDefinition, InterfaceDefinition delegateDefinition)
		//{
		//	throw new NotImplementedException();
		//}



		///// <summary>
		///// Generate a single output with a delegate
		///// </summary>
		///// <param name="outputDefinition"></param>
		///// <param name="delegateDefinition"></param>
		///// <returns></returns>
		//public string GenerateDelegate(OutputDefinition outputDefinition, DelegateDefinition delegateDefinition)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
