using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.CSharp
{
	public class EnumMemberDefinition : Definition
	{
		public EnumMemberDefinition()
		{
		}

		public string Value { get; set; }

		public CommentDefinition Comments { get; set; }
	}
}
