using Xunit;
using FluentAssertions;

namespace SixtenLabs.Spawn.Tests.Extensions
{
	public class StringExtensionTests
	{
		[Fact]
		public void xx()
		{
			var subject = "VK_TEST";

			var actual = subject.ConvertToTitleCase('_');

			actual.Should().Be("VkTest");
		}
	}
}
