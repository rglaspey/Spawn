using Xunit;
using FluentAssertions;
using NSubstitute;

namespace SixtenLabs.Spawn.Tests
{
	public class SpawnServiceTests
	{
		private SpawnService SubjectUnderTest()
		{
			return new SpawnService();
		}

		[Fact]
		public void xx()
		{
			var subject = SubjectUnderTest();

			//subject.AddDocumentToProject("test", "bobs", "", );
		}
	}
}
