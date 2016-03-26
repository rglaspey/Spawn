using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan.Model
{
	public class VulkanMember
	{
		public string Name { get; set; }

		public VulkanType Type { get; set; }

		public bool IsConst { get; set; }

		public int PointerRank { get; set; }

		public string Len { get; set; }
		//public bool ExternSync { get; set; }

		public bool NoAutoValidity { get; set; }

		public string Optional;

		public string SpecName { get; set; }

		public override string ToString() => $"{Type} {Name}";
	}
}
