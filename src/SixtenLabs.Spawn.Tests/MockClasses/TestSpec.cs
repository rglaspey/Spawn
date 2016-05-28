using AutoMapper;

namespace SixtenLabs.Spawn.Tests
{
	public class TestSpec : SpawnSpec<TestRegistry>
	{
		public TestSpec(XmlFileLoader xmlFileLoader, IMapper mapper)
			: base(xmlFileLoader, mapper)
		{
		}
	}
}
