using System.Collections.Generic;

namespace SixtenLabs.Spawn.CSharp
{
	public class AttributeDefinition : Definition
	{
		public AttributeDefinition()
		{
		}

		public IList<string> ArgumentList { get; } = new List<string>();
	}
}
