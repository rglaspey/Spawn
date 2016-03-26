using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define a class to generate.
	///  
	/// Can Contain
	///   constructors
	///   destructors
	///   constants
	///   fields
	///   methods
	///   properties
	///   indexers
	///   operators
	///   events
	///   delegates
	///   classes
	///   interfaces
	///   structs
	///   
	/// </summary>
  public class ClassDefinition : TypeDefinition
  {
    public ClassDefinition(string name)
      : base(name)
    {
    }

		public void AddField(string name, string returnType = "string", object defaultValue = null)
		{
			var fieldDefinition = name.CreateFieldDefinition(returnType, defaultValue);
			FieldDefinitions.Add(fieldDefinition);
		}

		public PropertyDefinition AddProperty(string name, string returnType = "string", object defaultValue = null)
		{
			var propertyDefinition = name.CreatePropertyDefinition(returnType, defaultValue);
			PropertyDefinitions.Add(propertyDefinition);

			return propertyDefinition;
		}

		public IList<FieldDefinition> FieldDefinitions { get; } = new List<FieldDefinition>();

		public IList<PropertyDefinition> PropertyDefinitions { get; } = new List<PropertyDefinition>();
  }
}
