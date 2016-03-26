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
		public ParameterDefinition(string name, string returnType)
			: base(name)
		{
			ReturnType = returnType;
		}

		public string ReturnType { get; }
	}
}
