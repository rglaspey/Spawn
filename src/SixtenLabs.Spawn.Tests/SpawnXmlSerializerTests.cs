﻿using Xunit;
using FluentAssertions;
using NSubstitute;

using SixtenLabs.Spawn.Tests.Model;
using System.IO;
using System.Dynamic;
using System.Collections.Generic;

namespace SixtenLabs.Spawn.Tests
{
	public class SpawnXmlSerializerTests
	{

		public SpawnXmlSerializer NewSubjectUnderTests()
		{
			return new SpawnXmlSerializer();
		}

		[Fact]
		public void SerializeClassWithListClass()
		{
			var subject = NewSubjectUnderTests();

			var testClass = new TestClassOne() { Name = "OneName", Description = "OneDescription" };
			testClass.Twos.Add(new TestClassTwo() { Name = "TwoName1", Description = "TwoDescription1" });
			testClass.Twos.Add(new TestClassTwo() { Name = "TwoName2", Description = "TwoDescription2" });

			var actual = SerializeData(subject, testClass, "root");

			actual.Should().Be(ClassWithListClass);
		}

		[Fact]
		public void SerializeAnonymousClassWithListClass()
		{
			var subject = NewSubjectUnderTests();

			var testClass = new
			{
				Name = "OneName",
				Description = "OneDescription",
				Twos = new[]
				{
					new
					{
						Name = "TwoName1", Description = "TwoDescription1" },
					new { Name = "TwoName2", Description = "TwoDescription2" }
				}
			};

			var actual = SerializeData(subject, testClass, "root");

			actual.Should().Be(ClassWithListClass);
		}

		[Fact(Skip = "Does not work with nested dynamic lists (why)")]
		public void SerializeDynamicClassWithListClass()
		{
			var subject = NewSubjectUnderTests();

			dynamic testClass = new ExpandoObject();
			testClass.Name = "OneName";
			testClass.Description = "OneDescription";

			testClass.Twos = new[]
				{
					new
					{
						Name = "TwoName1", Description = "TwoDescription1" },
					new { Name = "TwoName2", Description = "TwoDescription2" }
				};

			string actual = SerializeData(subject, testClass, "root");

			actual.Should().Be(ClassWithListClass);
		}

		private string ClassWithListClass { get; } = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <Name>OneName</Name>
  <Description>OneDescription</Description>
  <Twos>
    <TwosItem>
      <Name>TwoName1</Name>
      <Description>TwoDescription1</Description>
    </TwosItem>
    <TwosItem>
      <Name>TwoName2</Name>
      <Description>TwoDescription2</Description>
    </TwosItem>
  </Twos>
</root>";

		private string SerializeData(SpawnXmlSerializer serializer, dynamic data, string elementName)
		{
			string xmlData = null;

			using (var stream = new MemoryStream())
			{
				serializer.ToXml(data, stream, elementName);

				using (var reader = new StreamReader(stream))
				{
					stream.Position = 0;
					xmlData = reader.ReadToEnd();
				}
			}

			return xmlData;
		}
	}
}