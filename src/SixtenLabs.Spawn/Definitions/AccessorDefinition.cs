using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class AccessorDefinition : Definition
	{
		public AccessorDefinition(SyntaxKind accessorType, SyntaxKind modifier = SyntaxKind.None)
			: base(accessorType.ToString())
		{
			if (accessorType != SyntaxKind.GetAccessorDeclaration && accessorType != SyntaxKind.SetAccessorDeclaration)
			{
				throw new ArgumentOutOfRangeException("Parameter must be SyntaxKind.GetAccessorDeclaration or SyntaxKind.SetAccessorDeclaration");
			}

			AccessorType = accessorType;
			Modifier = modifier;
    }

		public void AddBlock(BlockDefinition block)
		{
			Block = block;
		}

		public SyntaxKind Modifier { get; }

		public SyntaxKind AccessorType { get; }

		public BlockDefinition Block { get; private set; }
	}
}
