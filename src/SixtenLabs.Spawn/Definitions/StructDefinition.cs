using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define a struct to generate.
	/// 
	/// A struct type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle
  /// or the characteristics of an item in an inventory.
	/// 
	/// Structs can contain:
	///   constructors
	///   constants
	///   fields
	///   methods
	///   properties
	///   indexers
	///   operators
	///   events
	///   nested types
	/// 
	/// </summary>
	public class StructDefinition : TypeDefinition
	{
		#region Constructors

		public StructDefinition(string name)
      : base(name)
    {
		}

		#endregion

		#region Public Methods

		public void AddField(string name, string returnType = "string", object defaultValue = null)
		{
			LiteralDefinition literalDefinition = null;

			if (defaultValue != null)
			{
				literalDefinition = new LiteralDefinition(defaultValue, defaultValue.GetType());
			}

			var fieldDefinition = new FieldDefinition(name, returnType, literalDefinition);
			FieldDefinitions.Add(fieldDefinition);
		}

		#endregion

		#region Properties

		public List<FieldDefinition> FieldDefinitions { get; } = new List<FieldDefinition>();

		#endregion
	}
}
