using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.CSharp
{
	public class PropertyDefinition : TypeMemberDefinition
	{
		public PropertyDefinition()
		{
		}

		public AccessorDefinition AddAccessor(SyntaxKind type, SyntaxKind modifier = SyntaxKind.None, string block = null)
		{
			var accessor = new AccessorDefinition() { AccessorType = type, Modifier = modifier };

			if (!string.IsNullOrEmpty(block))
			{
				var blockDefinition = new BlockDefinition() { SpecName = "block" };
				blockDefinition.AddStatement(block);
				accessor.AddBlock(blockDefinition);
			}

			return accessor;
    }

		public void AddGetter(SyntaxKind modifier = SyntaxKind.None, string block = null)
		{
			Getter = AddAccessor(SyntaxKind.GetAccessorDeclaration, modifier, block);
		}

		public void AddSetter(SyntaxKind modifier = SyntaxKind.None, string block = null)
		{
			Setter = AddAccessor(SyntaxKind.SetAccessorDeclaration, modifier, block);
		}
		
		/// <summary>
		/// The default value of the field. 
		/// Null by default
		/// </summary>
		public LiteralDefinition DefaultValue { get; set; }

		public AccessorDefinition Getter { get; set; }

		public AccessorDefinition Setter { get; set; }
	}
}
