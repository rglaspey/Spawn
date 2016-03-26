using Xunit;
using FluentAssertions;
using NSubstitute;
using System.Xml.Serialization;
using SixtenLabs.Spawn.Model;
using System.IO;
using System.Xml;

namespace SixtenLabs.Spawn.Tests.Model
{
	public class SerializationTest
	{
		[Fact]
		public void EnumSerialization()
		{
			var spawnEnum = new SpawnEnum();
			spawnEnum.Name = "TestSpawnEnum";
			spawnEnum.HasFlags = true;
			spawnEnum.EnumType = "int";
			spawnEnum.Comments.Add("Comment Line 1");

			spawnEnum.Members.Add(new SpawnEnumMember() { Name = "None", Value = "0", Comment = "zero comment" });
			spawnEnum.Members.Add(new SpawnEnumMember() { Name = "One", Value = "1", Comment = "one comment" });
			spawnEnum.Members.Add(new SpawnEnumMember() { Name = "Two", Value = "2", Comment = "two comment" });

			XmlSerializer xsSubmit = new XmlSerializer(typeof(SpawnEnum));

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
