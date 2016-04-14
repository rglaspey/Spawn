namespace SixtenLabs.Spawn
{
	public class ParameterDefinition : Definition
	{
		public ParameterDefinition()
		{
		}

		public bool IsOptional { get; set; }

		public bool IsPointer { get; set; }

		public bool IsPointerToPointer { get; set; }

		public bool IsArray { get; set; }

		public int ArrayCount { get; set; }

		/// <summary>
		/// figure out what to do with this information.
		/// </summary>
		public bool IsStruct { get; set; }

		public bool IsConst { get; set; }

		public bool ExternSync { get; set; }

		public string SpecType { get; set; }

		public string TranslatedSpecType { get; set; }
	}
}
