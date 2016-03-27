using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define an enum to Generate.
	/// 
	/// The enum keyword is used to declare an enumeration, 
	/// a distinct type that consists of a set of named constants called the enumerator list.
	/// 
	/// </summary>
	public class EnumDefinition : TypeDefinition
  {
		public EnumDefinition()
		{
		}

		public void AddEnumMembers(IEnumerable<EnumMemberDefinition> memberValues)
		{
			Members.AddRange(memberValues);
		}

    public void AddEnumMember(string memberName, string memberValue = null, string comment = null)
    {
      if(string.IsNullOrEmpty(memberName))
      {
        throw new ArgumentNullException("The member name must be defined");
      }

			var enumMember = new EnumMemberDefinition() { Name = memberName, Value = memberValue, Comment = comment };
			Members.Add(enumMember);
    }

		[XmlArray("Members")]
		[XmlArrayItem(typeof(EnumMemberDefinition), ElementName = "Member")]
		public List<EnumMemberDefinition> Members { get; } = new List<EnumMemberDefinition>();

    public bool HasFlags { get; set; }

		public string Expand { get; set; }

		public string Namespace { get; set; }

		public BaseType BaseType { get; set; }
  }
}
