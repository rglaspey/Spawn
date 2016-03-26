using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class PropertyDefinition : TypeMemberDefinition
	{
		public PropertyDefinition(string name, string returnType, LiteralDefinition defaultValue = null)
			: base(name, returnType)
		{
			DefaultValue = defaultValue;
		}

		public AccessorDefinition AddAccessor(SyntaxKind type, SyntaxKind modifier = SyntaxKind.None, string block = null)
		{
			var accessor = new AccessorDefinition(type, modifier);

			if (!string.IsNullOrEmpty(block))
			{
				var blockDefinition = new BlockDefinition("block");
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
		public LiteralDefinition DefaultValue { get; }

		public AccessorDefinition Getter { get; private set; }

		public AccessorDefinition Setter { get; private set; }
	}
}
