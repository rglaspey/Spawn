using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace SixtenLabs.Spawn
{
	public class AttributeDefinition : Definition
	{
		public AttributeDefinition(string name)
			: base(name)
		{
			// figure out how to build up attribute.
			Attribute = SF.AttributeList();
			Attribute.AddAttributes(SF.Attribute(SF.ParseName(name)));
		}

		public AttributeListSyntax Attribute { get; set; }
	}
}
