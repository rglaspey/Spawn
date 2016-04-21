using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public class ClassDefinition : TypeDefinition
	{
		public IList<ConstantDefinition> Constants { get; } = new List<ConstantDefinition>();
	}
}
