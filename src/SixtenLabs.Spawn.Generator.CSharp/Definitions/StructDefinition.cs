using System.Collections.Generic;

namespace SixtenLabs.Spawn.Generator.CSharp
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
			FieldDefinitions.Add(fieldDefinition);
		}

		public List<FieldDefinition> FieldDefinitions { get; } = new List<FieldDefinition>();
	}
}
