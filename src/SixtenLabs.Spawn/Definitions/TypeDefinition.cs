using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn
{
	public class TypeDefinition : BaseTypeDefinition
	{
		public TypeDefinition()
		{
		}

		[XmlArray("Comments")]
		[XmlArrayItem(typeof(string), ElementName = "Comment")]
		public IList<string> Comments { get; } = new List<string>();
	}
}
