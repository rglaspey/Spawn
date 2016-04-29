using System.Collections.Generic;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public class MethodDefinition : TypeMemberDefinition
	{
		public MethodDefinition()
		{
		}

		public void AddCodeLineToBody(string code)
		{
			if(Block == null)
			{
				var body = new BlockDefinition() { SpecName = "body" };
				AddBlock(body);
			}

			Block.AddStatement(code);
		}

		public List<AttributeDefinition> Attributes { get; } = new List<AttributeDefinition>();
	}
}