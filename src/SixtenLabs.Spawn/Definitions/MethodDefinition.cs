using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class MethodDefinition : TypeMemberDefinition
	{
		#region Constructors

		public MethodDefinition(string name, string returnType)
			: base(name, returnType)
		{
		}

		#endregion

		#region Public Methods

		public void AddCodeLineToBody(string code)
		{
			if(Block == null)
			{
				var body = new BlockDefinition("body");
				AddBlock(body);
			}

			Block.AddStatement(code);
		}

		#endregion

		#region Properties


		#endregion
	}
}