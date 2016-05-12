using Microsoft.CodeAnalysis.CSharp;
using System;

namespace SixtenLabs.Spawn.CSharp
{
	public class AccessorDefinition : Definition
	{
		public AccessorDefinition()
		{
			//if (accessorType != SyntaxKind.GetAccessorDeclaration && accessorType != SyntaxKind.SetAccessorDeclaration)
			//{
			//	throw new ArgumentOutOfRangeException("Parameter must be SyntaxKind.GetAccessorDeclaration or SyntaxKind.SetAccessorDeclaration");
			//}
    }

		public void AddBlock(BlockDefinition block)
		{
			Block = block;
		}

		public SyntaxKind Modifier { get; set; }

		public SyntaxKind AccessorType { get; set; }

		public BlockDefinition Block { get; private set; }
	}
}
