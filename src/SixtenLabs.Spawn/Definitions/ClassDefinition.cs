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
      LiteralDefinition literalDefinition = null;

      if(defaultValue != null)
      {
        literalDefinition = new LiteralDefinition(defaultValue, defaultValue.GetType());
      }
      
			var fieldDefinition = new FieldDefinition(name, returnType, literalDefinition);
			Fields.Add(fieldDefinition);
		}

		public PropertyDefinition AddProperty(string name, string returnType = "string", object defaultValue = null)
		{
			LiteralDefinition literalDefinition = null;

			if (defaultValue != null)
			{
				literalDefinition = new LiteralDefinition(defaultValue, defaultValue.GetType());
			}

			var definition = new PropertyDefinition(name, returnType, literalDefinition);
			Properties.Add(definition);

			return definition;
		}

		#endregion

		#region Properties

		public IList<FieldDefinition> Fields { get; } = new List<FieldDefinition>();

		public IList<PropertyDefinition> Properties { get; } = new List<PropertyDefinition>();

    #endregion
  }
}
