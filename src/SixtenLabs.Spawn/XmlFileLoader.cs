using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn.Utility
{
	/// <summary>
	/// This class is responsible for loading the xml file
	/// and serializing it to the classes generated from the xsd.
	/// </summary>
	public class XmlFileLoader<T> where T : class
	{
		public XmlFileLoader(IGeneratorSettings parseSettings)
		{
			ParseSettings = parseSettings;
		}

		private void LoadFromUri()
		{
			string xml = new WebClient().DownloadString(ParseSettings.WebUri);

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

		public T Registry { get; set; }
	}
}
