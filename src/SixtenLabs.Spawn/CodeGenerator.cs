using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace SixtenLabs.Spawn
{
  public abstract class CodeGenerator : ICodeGenerator
  {
    public CodeGenerator(ISpawnService spawn, IXmlSerializer serializer)
    {
			Spawn = spawn;
			Serializer = serializer;
    }

		public string SerializeData(dynamic data, string elementName)
		{
			string xmlData = null;

			using (var stream = new MemoryStream())
			{
				Serializer.ToXml(data, stream, elementName);

				using (var reader = new StreamReader(stream))
				{
					stream.Position = 0;
					xmlData = reader.ReadToEnd();
				}
			}

			return xmlData;
		}
		
		protected void AddToProject(IOutputDefinition outputDefinition, string contents)
		{
			Spawn.AddDocumentToProject(outputDefinition.TargetSolution, outputDefinition.FileName, contents, new[] { outputDefinition.OutputDirectory });
		}

		protected ISpawnService Spawn { get; }

		protected IXmlSerializer Serializer { get; }
	}
}
