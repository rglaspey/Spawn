﻿using System.Collections.Generic;

namespace SixtenLabs.Spawn.CSharp
{
	/// <summary>
	/// Define an enum to Generate.
	/// 
	/// The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.
	/// 
	/// </summary>
	public class EnumDefinition : TypeDefinition
  {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="baseType"></param>
		/// <param name="hasFlags"></param>
    public EnumDefinition()
    {
    }

    public IList<EnumMemberDefinition> Members { get; set; } = new List<EnumMemberDefinition>();

    public bool HasFlags { get; set; }

    public SyntaxKindDto BaseType { get; set; }
  }
}
