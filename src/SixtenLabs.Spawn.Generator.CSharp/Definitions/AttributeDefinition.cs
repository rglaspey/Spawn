using System.Collections.Generic;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public class AttributeDefinition : Definition
	{
		public AttributeDefinition()
		{
		}

		public IList<string> ArgumentList { get; } = new List<string>();
	}
}
