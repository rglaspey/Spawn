using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn.Model
{
	public class SpawnEnum
	{
		public SpawnEnum()
		{
		}

		public string Namespace { get; set; }

		public string Name { get; set; }

		public string EnumType { get; set; }
		
		public bool HasFlags { get; set; }

		[XmlArray("Comments")]
		[XmlArrayItem(typeof(string), ElementName = "Comment")]
		public List<string> Comments { get; } = new List<string>();

		[XmlArray("Members")]
		[XmlArrayItem(typeof(SpawnEnumMember), ElementName = "Member")]
		public List<SpawnEnumMember> Members { get; } = new List<SpawnEnumMember>();
	}
}
