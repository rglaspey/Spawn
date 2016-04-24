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
		
		protected string TransformXmlFromTemplate(string templateName, string xmlData)
		{
			var transformer = new XslCompiledTransform(true);
			var argumentList = new XsltArgumentList();

			transformer.Load($"Templates/{templateName}.xslt");

			string result;

			using (StringReader sr = new StringReader(xmlData))
			{
				using (var xr = XmlReader.Create(sr))
				{
					using (StringWriter sw = new StringWriter())
					{
						transformer.Transform(xr, argumentList, sw);
						result = sw.ToString();
					}
				}
			}

			return result;
		}

		public abstract void GenerateCodeFile<T>(IOutputDefinition<T> outputDefinition) where T : IDefinition;

		protected ISpawnService Spawn { get; }

		protected IXmlSerializer Serializer { get; }
	}
}
