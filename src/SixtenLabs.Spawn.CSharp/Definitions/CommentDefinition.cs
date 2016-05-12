using System.Collections.Generic;

namespace SixtenLabs.Spawn.CSharp
{
	public class CommentDefinition : Definition
	{
		public CommentDefinition()
		{
		}

		public bool HasComments
		{
			get
			{
				return CommentLines.Count > 0;
			}
		}

		public IList<string> CommentLines { get; set; } = new List<string>(); 
	}
}
