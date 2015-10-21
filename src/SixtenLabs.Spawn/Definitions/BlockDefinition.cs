using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class BlockDefinition : Definition
	{
		#region Constructors

		public BlockDefinition(string name)
			: base(name)
		{
		}

		#endregion

		#region Public Methods

		public void AddStatement(string code)
		{
			var definition = new StatementDefinition("statement", code);
			Statements.Add(definition);
		}

		#endregion

		#region Properties

		public IList<StatementDefinition> Statements { get; } = new List<StatementDefinition>();

		#endregion
	}
}
