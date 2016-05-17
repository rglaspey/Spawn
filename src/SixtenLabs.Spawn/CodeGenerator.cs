using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace SixtenLabs.Spawn
{
  public abstract class CodeGenerator : ICodeGenerator
  {
    public CodeGenerator(ISpawnService spawn)
    {
			Spawn = spawn;
    }

		protected void AddToProject(IOutputDefinition outputDefinition, string contents)
		{
			Spawn.AddDocumentToProject(outputDefinition.TargetSolution, outputDefinition.FileName, contents, new[] { outputDefinition.OutputDirectory });
		}

		protected ISpawnService Spawn { get; }
	}
}
