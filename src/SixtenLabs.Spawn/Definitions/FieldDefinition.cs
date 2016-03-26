using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// internal static ActiveShaderProgram glActiveShaderProgram;
	/// </summary>
	public class FieldDefinition : TypeMemberDefinition
	{
		public FieldDefinition(string name, string returnType, LiteralDefinition defaultValue = null)
			: base(name, returnType)
		{
			DefaultValue = defaultValue;
		}

		/// <summary>
		/// The default value of the field. 
		/// Null by default
		/// </summary>
		public LiteralDefinition DefaultValue { get; }
	}
}
