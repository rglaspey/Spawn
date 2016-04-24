using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class DelegateDefinition : BaseDefinition
	{
		public string SpecReturnType { get; set; }

		public string TranslatedReturnType { get; set; }

		public IList<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();

		public List<string> Comments { get; set; } = new List<string>();
	}
}
