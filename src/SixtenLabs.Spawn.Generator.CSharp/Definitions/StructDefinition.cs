using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class StructDefinition : BaseDefinition
	{
		public StructDefinition()
		{
		}

		public List<FieldDefinition> Fields { get; } = new List<FieldDefinition>();
	}
}
