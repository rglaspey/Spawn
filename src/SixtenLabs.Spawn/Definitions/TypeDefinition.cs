using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public class TypeDefinition : BaseTypeDefinition
	{
		public TypeDefinition()
		{
		}

		public IList<string> Comments { get; } = new List<string>();

		public IList<AttributeDefinition> Attributes { get; } = new List<AttributeDefinition>();
	}
}
