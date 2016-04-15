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

		public string LengthPropertyName { get; set; }

		public int ArrayCount { get; set; }

		/// <summary>
		/// figure out what to do with this information.
		/// </summary>
		public bool IsStruct { get; set; }

		public bool IsConst { get; set; }

		/// <summary>
		/// This is named for vulkan. figure out what this should be or if we should ignore it.
		/// </summary>
		public bool ExternSync { get; set; }

		/// <summary>
		/// This is named for vulkan. figure out what this should be or if we should ignore it.
		/// </summary>
		public string ExternSyncData { get; set; }

		public string SpecType { get; set; }

		public string TranslatedSpecType { get; set; }
	}
}
