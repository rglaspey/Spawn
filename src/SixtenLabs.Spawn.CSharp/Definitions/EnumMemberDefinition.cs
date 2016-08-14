namespace SixtenLabs.Spawn.CSharp
{
	public class EnumMemberDefinition : Definition
	{
		public EnumMemberDefinition()
		{
		}

		public string Value { get; set; }

		public CommentDefinition Comments { get; set; } = new CommentDefinition();
	}
}
