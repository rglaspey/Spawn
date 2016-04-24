using System;
using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define an enum to Generate.
	/// 
	/// The enum keyword is used to declare an enumeration, 
	/// a distinct type that consists of a set of named constants called the enumerator list.
	/// 
	/// </summary>
	public class EnumDefinition : BaseDefinition
  {
		public EnumDefinition()
		{
		}

		public void AddEnumMembers(IEnumerable<EnumMemberDefinition> memberValues)
		{
			Members.AddRange(memberValues);
		}

    public void AddEnumMember(string memberSpecName, string memberName, string memberValue = null, string comment = null)
    {
      if(string.IsNullOrEmpty(memberSpecName))
      {
        throw new ArgumentNullException("The member spec name must be defined");
      }

			var enumMember = new EnumMemberDefinition() { SpecName = memberSpecName, TranslatedName = memberName, Value = memberValue, Comment = comment };
			Members.Add(enumMember);
    }

		public List<EnumMemberDefinition> Members { get; } = new List<EnumMemberDefinition>();

		public List<string> Comments { get; set; } = new List<string>();

		public bool HasFlags { get; set; }
  }
}
