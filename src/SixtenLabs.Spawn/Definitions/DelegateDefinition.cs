using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class DelegateDefinition : TypeDefinition
	{
		public IList<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();
	}
}
