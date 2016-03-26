using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn.Model
{
	[XmlRoot("SpawnEnum")]
	public class SpawnEnumMember
	{
		public SpawnEnumMember()
		{
		}

		public string Name { get; set; }

		public string Value { get; set; }

		public string Comment { get; set; }
	}
}
