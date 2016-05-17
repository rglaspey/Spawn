using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// This class is responsible for loading the xml file
	/// and serializing it to the classes generated from the xsd.
	/// </summary>
	public class XmlFileLoader<T> where T : class
	{
		public XmlFileLoader(IGeneratorSettings parseSettings, IWebClientFactory webClientFactory)
		{
			ParseSettings = parseSettings;
			WebClientFactory = webClientFactory;
		}

		private void LoadFromUri()
		{
			string xml = WebClientFactory.DownloadSpecFromUri(ParseSettings.WebUri);

			var buffer = Encoding.UTF8.GetBytes(xml);
			ParseFile(buffer);
		}

		private void LoadFromFile()
		{
			var buffer = File.ReadAllBytes(ParseSettings.FileName);

			ParseFile(buffer);
		}

		private void ParseFile(byte[] xml)
		{
			using (var stream = new MemoryStream(xml))
			{
				XmlSerializer s = new XmlSerializer(typeof(T));
				Registry = (T)s.Deserialize(stream);
			}
		}

		public void LoadRegistry()
		{
			if (ParseSettings.LoadMethod == XmlLoadMethod.FromFile)
			{
				LoadFromFile();
			}
			else if (ParseSettings.LoadMethod == XmlLoadMethod.FromUri)
			{
				LoadFromUri();
			}
		}

		private IGeneratorSettings ParseSettings { get; }

		private IWebClientFactory WebClientFactory { get; }

		public T Registry { get; set; }
	}
}
