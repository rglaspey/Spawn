using System.Collections.Generic;

namespace SixtenLabs.Spawn.CSharp
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
		public StructDefinition()
    {
		}

		public void AddField(string name, string returnType = "string", string defaultValue = null)
		{
			LiteralDefinition literalDefinition = null;

			if (defaultValue != null)
			{
				literalDefinition = new LiteralDefinition() { Value = defaultValue, LiteralType = defaultValue.GetType() };
			}

			var fieldDefinition = new FieldDefinition() { SpecName = name, SpecReturnType = returnType, DefaultValue = literalDefinition };
			Fields.Add(fieldDefinition);
		}

		public string SpecDerivedType { get; set; }

		public string DerivedType { get; set; }

		public bool NeedsMarshalling { get; set; }

		public List<FieldDefinition> Fields { get; } = new List<FieldDefinition>();
	}
}
