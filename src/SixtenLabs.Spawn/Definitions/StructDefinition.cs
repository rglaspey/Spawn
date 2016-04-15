using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class StructDefinition : TypeDefinition
	{
		public StructDefinition()
		{
		}

		public void AddField(string specName, string name, string specType, string @type)
		{
			var field = new FieldDefinition() { SpecName = specName, TranslatedName = name, SpecType = specType, Type = @type };

			Fields.Add(field);
		}

		public IList<FieldDefinition> Fields { get; } = new List<FieldDefinition>();

		public bool ReturnedOnly { get; set; }

		public List<string> Validity { get; } = new List<string>();
	}
}
