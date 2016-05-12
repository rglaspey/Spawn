using System.Collections.Generic;

namespace SixtenLabs.Spawn.CSharp
{
	public abstract class TypeMemberDefinition : BaseTypeDefinition
	{
		protected TypeMemberDefinition()
		{
		}

		protected void AddBlock(BlockDefinition block)
		{
			Block = block;
		}

		public void AddParameter(string name, string specReturnType)
		{
			var parameterDefinition = new ParameterDefinition() { SpecName = name, SpecReturnType = specReturnType };
			Parameters.Add(parameterDefinition);
		}

		public string SpecType { get; set; }

		public string TranslatedType { get; set; }

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

		public string SpecValue { get; set; }

		public string TranslatedValue { get; set; }

		public List<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();

		public BlockDefinition Block { get; private set; }
	}
}
