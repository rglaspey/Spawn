using Xunit;
using FluentAssertions;
using NSubstitute;

using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;

namespace SixtenLabs.Spawn.Tests.Model
{
	public class SerializationTest
	{
		[Fact]
		public void EnumSerialization()
		{
			var spawnEnum = new EnumDefinition();
			spawnEnum.TranslatedName = "TestSpawnEnum";
			spawnEnum.HasFlags = true;
			//spawnEnum.BaseType = BaseType.Integer;
			spawnEnum.Comments.Add("Comment Line 1");

			spawnEnum.AddEnumMember("None", "0", "zero comment");
			spawnEnum.AddEnumMember("One", "1", "one comment");
			spawnEnum.AddEnumMember("Two", "2", "two comment");

			XmlSerializer xsSubmit = new XmlSerializer(typeof(EnumDefinition));

			using (StringWriter sww = new StringWriter())
			{
				using (XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, spawnEnum);
					var xml = sww.ToString(); // Your XML
				}
			}
		}

		public class EnumDefinition
		{
			public void AddEnumMembers(IEnumerable<EnumMemberDefinition> memberValues)
			{
				Members.AddRange(memberValues);
			}

			public void AddEnumMember(string memberSpecName, string memberName, string memberValue = null, string comment = null)
			{
				if (string.IsNullOrEmpty(memberSpecName))
				{
					throw new ArgumentNullException("The member spec name must be defined");
				}

				var enumMember = new EnumMemberDefinition() { SpecName = memberSpecName, TranslatedName = memberName, Value = memberValue, Comment = comment };
				Members.Add(enumMember);
			}

			public List<EnumMemberDefinition> Members { get; } = new List<EnumMemberDefinition>();

			public List<string> Comments { get; set; } = new List<string>();

			public bool HasFlags { get; set; }

			public string SpecName { get; set; }

			public string TranslatedName { get; set; }
		}

		public class EnumMemberDefinition
		{
			public EnumMemberDefinition()
			{
			}

			public string Value { get; set; }

			public string Comment { get; set; }

			public string SpecName { get; set; }

			public string TranslatedName { get; set; }
		}
	}
}
