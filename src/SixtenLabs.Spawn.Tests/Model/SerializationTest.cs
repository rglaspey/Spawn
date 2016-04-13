using Xunit;
using FluentAssertions;
using NSubstitute;

using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
			spawnEnum.AddEnumMember("One", "1", "one comment" );
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
	}
}
