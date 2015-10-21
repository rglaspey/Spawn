using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn.OpenGL.Generator
{
  /// <summary>
  /// This class is responsible for loading the xml file
  /// and serializing it to the classes generated from the xsd.
  /// </summary>
  public class RegistryLoader
  {
    #region Constructors

    public RegistryLoader(RegistryGeneratorSettings parseSettings)
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
      XmlSerializer serializer = new XmlSerializer(typeof(registry));

      var stream = new MemoryStream(xml, false);

      Registry = (registry)serializer.Deserialize(stream);
    }

    #endregion

    #region Public Methods

    public registry LoadRegistry()
    {
      if(ParseSettings.LoadMethod == RegistryLoadMethod.FromFile)
      {
        LoadFromFile();
      }
      else if(ParseSettings.LoadMethod == RegistryLoadMethod.FromUri)
      {
        LoadFromUri();
      }

      return Registry;
    }

    #endregion

    #region Properties
    
    private RegistryGeneratorSettings ParseSettings { get; }

    private registry Registry { get; set; }

    #endregion
  }
}
