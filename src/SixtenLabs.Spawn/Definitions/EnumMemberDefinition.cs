using System.Xml.Serialization;

namespace SixtenLabs.Spawn
{
	[XmlRoot("EnumDefinition")]
	public class EnumMemberDefinition
	{
		public EnumMemberDefinition()
		{
		}

		public string Name { get; set; }

		public string Value { get; set; }

		public string Comment { get; set; }
	}
}
