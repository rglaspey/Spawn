using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
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
    public EnumDefinition(string name, SyntaxKindX baseType = SyntaxKindX.IntKeyword, bool hasFlags = false)
      : base(name)
    {
      BaseType = baseType;
      HasFlags = hasFlags;
    }

    public void AddEnumMember(string memberName, string memberValue = null, string comment = null)
    {
      if(string.IsNullOrEmpty(memberName))
      {
        throw new ArgumentNullException("The member name must be defined");
      }

      MemberNames.Add(memberName);

      if(!string.IsNullOrEmpty(memberValue))
      {
        MemberValues.Add(memberName, memberValue);
      }

      if(!string.IsNullOrEmpty(comment))
      {
        MemberComments.Add(memberName, comment);
      }
    }

    public IList<string> MemberNames { get; } = new List<string>();

    public IDictionary<string, string> MemberValues { get; } = new Dictionary<string, string>();

    public IDictionary<string, string> MemberComments { get; } = new Dictionary<string, string>();

    public bool HasFlags { get; }

    public SyntaxKindX BaseType { get; }
  }
}
