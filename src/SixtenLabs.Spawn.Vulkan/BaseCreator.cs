using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Utility
{
	public abstract class BaseCreator : ICreator
	{
		public BaseCreator(ICodeGenerator generator, IVulkanSpec rules, int order, string name, string typeName)
		{
			Generator = generator;
			Name = name;
			TypeName = typeName;
			VulkanSpec = rules;
			Order = order;
		}

		public abstract void MapTypes();

		public abstract void Rewrite();

		public abstract void Build();

		public abstract void Create();

		protected ICodeGenerator Generator { get; }

		public string TargetSolution { get; set; }

		public string TargetNamespace { get; set; }

		public int NumberCreated { get; set; }

		public string Name { get; }

		public string TypeName { get; }

		protected IVulkanSpec VulkanSpec { get; }

		public int Order { get; set; }

		/// <summary>
		/// Used to populate a generated code message in the top level type comments.
		/// </summary>
		public List<string> GeneratedComments { get; } = new List<string>();
	}
}
