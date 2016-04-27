namespace SixtenLabs.Spawn.Generator.CSharp
{
	/// <summary>
	/// internal static ActiveShaderProgram glActiveShaderProgram;
	/// </summary>
	public class FieldDefinition : TypeMemberDefinition
	{
		public FieldDefinition()
		{
		}

		/// <summary>
		/// The default value of the field. 
		/// Null by default
		/// </summary>
		public LiteralDefinition DefaultValue { get; set; }
	}
}
