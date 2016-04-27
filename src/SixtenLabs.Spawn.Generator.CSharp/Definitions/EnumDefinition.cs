using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Generator.CSharp
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

    public void AddEnumMember(string memberName, string memberValue = null, string comment = null)
    {
      if(string.IsNullOrEmpty(memberName))
      {
        throw new ArgumentNullException("The member name must be defined");
      }

			var enumMember = new EnumMemberDefinition() { SpecName = memberName, Value = memberValue, Comment = comment };
      Members.Add(enumMember);
    }

    public IList<EnumMemberDefinition> Members { get; } = new List<EnumMemberDefinition>();

    public bool HasFlags { get; set; }

    public SyntaxKindDto BaseType { get; set; }
  }
}
