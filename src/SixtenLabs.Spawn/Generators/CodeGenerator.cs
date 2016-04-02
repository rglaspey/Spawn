using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
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

		//protected string SerializeDefinition<T>(T definition) where T : class
		//{
		//	string xml = null;

		//	var serializer = new XmlSerializer(typeof(T));

		//	using (StringWriter sw = new StringWriter())
		//	{
		//		serializer.Serialize(sw, definition);
		//		xml = sw.ToString();
		//	}

		//	return xml;
		//}

		//protected string LoadTemplate(string templateName)
		//{
		//	string template = null;

		//	var assembly = Assembly.GetExecutingAssembly();
		//	var resourceName = $"SixtenLabs.Spawn.Templates.{templateName}.xslt";

		//	using (var stream = assembly.GetManifestResourceStream(resourceName))
		//	{
		//		using (var reader = new StreamReader(stream))
		//		{
		//			template = reader.ReadToEnd();
		//		}
		//	}

		//	return template;
		//}

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

		//protected string TransformXmlFromTemplate(string xml, string template)
		//{
		//	string output = string.Empty;

		//	var xpd = new XPathDocument(new StringReader(xml));

		//	var transform = new XslCompiledTransform();
		//	transform.Load(new XmlTextReader(template, XmlNodeType.Document, null));

		//	using (var sr = new StringWriter())
		//	{
		//		transform.Transform(xpd.CreateNavigator(), null, sr);
		//		output = sr.ToString();
		//	}

		//	// The output is incorrect. WHY?

		//	return output;
		//}

		public abstract void GenerateCodeFile<T>(OutputDefinition<T> outputDefinition) where T : TypeDefinition;

		protected ISpawnService Spawn { get; }

		protected IXmlSerializer Serializer { get; }
	}
}
