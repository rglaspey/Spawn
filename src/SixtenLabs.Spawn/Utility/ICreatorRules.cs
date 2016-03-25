using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Utility
{
	public interface ICreatorRules
	{
		void ProcessRegistry();

		void MapType(string name, string transformedName);

		IEnumerable<XElement> GetTypes(string type);

		string TransformedName(string key);

		XElement SpecTree { get; }
	}
}
