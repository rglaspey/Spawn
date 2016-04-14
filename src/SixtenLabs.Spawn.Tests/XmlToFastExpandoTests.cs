using Xunit;
using FluentAssertions;
using NSubstitute;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using SixtenLabs.Spawn.Utility;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace SixtenLabs.Spawn.Tests
{
	public class XmlToFastExpandoTests
	{
		public XmlToFastExpandoTests()
		{
			var registryElement = LoadFile();
			SubjectUnderTest = XmlToObjectParser.ParseFromXml(registryElement);
		}

		private dynamic SubjectUnderTest { get; set; }

		[Fact]
		public void ParseFromXml_Comment_IsCorrect()
		{
			var actual = (string)SubjectUnderTest.comment;

			actual.Should().Contain("without limitation the rights to use, copy, modify, merge, publish,");
		}

		[Fact]
		public void ParseFromXml_vendorids_xx()
		{
			var actual = (int)SubjectUnderTest.vendorids.vendorid.Count;

			actual.Should().Be(3);
		}

		private XElement LoadFile()
		{
			var buffer = File.ReadAllBytes("Spec/vk.xml");

			return ParseFile(buffer);
		}

		private XElement ParseFile(byte[] xml)
		{
			using (var stream = new MemoryStream(xml))
			{
				var registryElement = XElement.Load(stream);

				return registryElement;
			}
		}
	}
}
