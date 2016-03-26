using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public abstract class TypeMemberDefinition : BaseTypeDefinition
	{
		protected TypeMemberDefinition(string name, string returnType)
			: base(name)
		{
			ReturnType = returnType;
		}

		protected void AddBlock(BlockDefinition block)
		{
			Block = block;
		}

		public void AddParameter(string name, string returnType)
		{
			var parameterDefinition = new ParameterDefinition(name, returnType);
			Parameters.Add(parameterDefinition);
		}

		public string ReturnType { get; }

		public bool HasBlock
		{
			get
			{
				return Block != null;
			}
		}

		public bool HasParameters
		{
			get
			{
				return Parameters.Count > 0;
			}
		}

		public IList<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();

		public BlockDefinition Block { get; private set; }
	}
}
