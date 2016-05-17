using AutoMapper;
using System;

namespace SixtenLabs.Spawn.Tests
{
	public class TestCreator : BaseCreator<TestRegistry, string>
	{
		public TestCreator(ICodeGenerator generator, ISpawnSpec<TestRegistry> spawnSpec)
			: base(generator, spawnSpec, 10)
		{
		}

		public override int Rewrite()
		{
			throw new NotImplementedException();
		}

		public override int Build(IMapper mapper)
		{
			throw new NotImplementedException();
		}

		public override int Create()
		{
			throw new NotImplementedException();
		}
	}
}
