using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Utility
{
	public abstract class BaseCreator : ICreator
	{
		public BaseCreator(ISpawn spawn, ICodeGenerator generator, IVulkanSpec rules, int order, string name, string typeName)
		{
			Spawn = spawn;
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

		protected ISpawn Spawn { get; }

		protected ICodeGenerator Generator { get; }

		public string TargetSolution { get; set; }

		public string TargetNamespace { get; set; }

		public int NumberCreated { get; set; }

		public string Name { get; }

		public string TypeName { get; }

		protected IVulkanSpec VulkanSpec { get; }

		public int Order { get; set; }
	}
}
