using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Tests.Model
{
	public class TestClassOne
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public IList<TestClassTwo> Twos { get; } = new List<TestClassTwo>();
	}
}
