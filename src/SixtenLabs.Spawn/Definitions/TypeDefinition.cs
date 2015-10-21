using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public abstract class TypeDefinition : BaseTypeDefinition
	{
		#region Constructors

		protected TypeDefinition(string name)
			: base(name)
		{
		}

		#endregion
	}
}
