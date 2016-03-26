using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class BlockDefinition : Definition
	{
		public BlockDefinition(string name)
			: base(name)
		{
		}

		public void AddStatement(string code)
		{
			var definition = new StatementDefinition("statement", code);
			Statements.Add(definition);
		}

		public IList<StatementDefinition> Statements { get; } = new List<StatementDefinition>();
	}
}
