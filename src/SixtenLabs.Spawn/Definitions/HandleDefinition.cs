using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class HandleDefinition : TypeDefinition
	{
		public HandleDefinition()
		{

		}

		public string HandleType { get; set; }

		public string Parent { get; set; }
	}
}
