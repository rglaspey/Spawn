using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Utility
{
	/// <summary>
	/// This class is responsible for loading the xml file
	/// and serializing it to the classes generated from the xsd.
	/// </summary>
	public class XmlFileLoader
	{
		#region Constructors

		public XmlFileLoader(IGeneratorSettings parseSettings)
		{
			ParseSettings = parseSettings;
		}

		#endregion

		#region Private Methods

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
				Registry = XElement.Load(stream);
			}
		}

		#endregion

		#region Public Methods

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

		#endregion

		#region Properties

		private IGeneratorSettings ParseSettings { get; }

		public XElement Registry { get; set; }

		#endregion
	}
}
