using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	public class BlockDefinition : Definition
	{
		public BlockDefinition()
		{
		}

		public void AddStatement(string code)
		{
			var definition = new StatementDefinition() { SpecName = "statement", Code = code };
			Statements.Add(definition);
		}

		public IList<StatementDefinition> Statements { get; } = new List<StatementDefinition>();
	}
}
