using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.CSharp
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
    public ClassDefinition()
    {
    }

		public void AddField(string name, string returnType = "string", string defaultValue = null)
		{
      LiteralDefinition literalDefinition = null;

      if(defaultValue != null)
      {
        literalDefinition = new LiteralDefinition() { Value = defaultValue, LiteralType = defaultValue.GetType() };
      }

			var fieldDefinition = new FieldDefinition() { SpecName = name, SpecReturnType = returnType, DefaultValue = literalDefinition };
			Fields.Add(fieldDefinition);
		}

		public PropertyDefinition AddProperty(string name, string returnType = "string", string defaultValue = null)
		{
			LiteralDefinition literalDefinition = null;

			if (defaultValue != null)
			{
				literalDefinition = new LiteralDefinition() { Value = defaultValue, LiteralType = defaultValue.GetType() };
			}

			var definition = new PropertyDefinition() { SpecName = name, SpecReturnType = returnType, DefaultValue = literalDefinition };
			Properties.Add(definition);

			return definition;
		}

		public string SpecDerivedType { get; set; }

		public string DerivedType { get; set; }

		public IList<FieldDefinition> Fields { get; set; } = new List<FieldDefinition>();

		public IList<PropertyDefinition> Properties { get; set; } = new List<PropertyDefinition>();

		public List<MethodDefinition> Methods { get; set; } = new List<MethodDefinition>();

		public List<AttributeDefinition> Attributes { get; set; } = new List<AttributeDefinition>();
	}
}
