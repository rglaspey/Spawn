using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using System;

namespace SixtenLabs.Spawn
{
  public abstract class CodeGenerator : ICodeGenerator
  {
    public CodeGenerator()
    {
    }

		public virtual string GenerateEnum(OutputDefinition outputDefinition, EnumDefinition enumDefinition)
		{
			throw new NotImplementedException();
		}
	}
}
