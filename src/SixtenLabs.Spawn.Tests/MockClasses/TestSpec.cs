using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Tests
{
	public class TestSpec : SpawnSpec<TestRegistry>
	{
		public TestSpec(XmlFileLoader<TestRegistry> xmlFileLoader)
			: base(xmlFileLoader)
		{
		}

	}
}
