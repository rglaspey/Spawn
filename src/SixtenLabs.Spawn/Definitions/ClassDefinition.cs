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
    #region Constructors

    public ClassDefinition(string name)
      : base(name)
    {
    }

		#endregion

		#region Public Methods

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

		#endregion

		#region Properties

		public IList<FieldDefinition> FieldDefinitions { get; } = new List<FieldDefinition>();

		public IList<PropertyDefinition> PropertyDefinitions { get; } = new List<PropertyDefinition>();

    #endregion
  }
}
