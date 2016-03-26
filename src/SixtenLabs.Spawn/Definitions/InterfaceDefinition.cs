using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// An interface contains only the signatures of methods, properties, events or indexers. 
	/// A class or struct that implements the interface must implement the members of the interface that are specified in the interface definition. 
	/// </summary>
	public class InterfaceDefinition : TypeDefinition
	{
		public InterfaceDefinition(string name)
      : base(name)
    {
		}

		public List<FieldDefinition> FieldDefinitions { get; } = new List<FieldDefinition>();
	}
}
