using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class ParameterDefinition : BaseTypeDefinition
	{
		#region Constructors

		public ParameterDefinition(string name, string returnType)
			: base(name)
		{
			ReturnType = returnType;
		}

		#endregion

		#region Properties

		public string ReturnType { get; }

		#endregion
	}
}
