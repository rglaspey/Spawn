using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class VulkanGenerator
	{
		public VulkanGenerator(IEnumerable<ICreator> creators, ISpawnService spawn, IVulkanSpec rules)
		{
			Creators = creators;
			Spawn = spawn;
			Rules = rules;
		}

		public void Initialize()
		{
			Spawn.Initialize(@"C:\Users\pglas\Documents\GitHub\SixtenLabs\Spawn\Spawn.sln");
			Rules.ProcessRegistry();
		}

		public void MapTypes()
		{
			var orderedCreators = Creators.OrderBy(x => x.Order);

			foreach (var creator in orderedCreators)
			{
				Console.WriteLine($"Mapping {creator.TypeName} files.");
				creator.MapTypes();
				Console.WriteLine($"Mapped {creator.NumberCreated} {creator.TypeName} files.");
			}
		}

		public void Rewrite()
		{
			var orderedCreators = Creators.OrderBy(x => x.Order);

			foreach (var creator in orderedCreators)
			{
				Console.WriteLine($"Rewriting {creator.TypeName} files.");
				creator.Rewrite();
				Console.WriteLine($"Rewrote {creator.NumberCreated} {creator.TypeName} files.");
			}
		}

		public void Build()
		{
			foreach (var creator in Creators)
			{
				Console.WriteLine($"Building {creator.TypeName} definition files.");
				creator.Build();
				Console.WriteLine($"Building {creator.NumberCreated} {creator.TypeName} definition files.");
			}
		}

		public void Generate()
		{
			foreach (var creator in Creators)
			{
				creator.TargetSolution = "SixtenLabs.Spawn.Vulkan.Target";
				creator.TargetNamespace = "SixtenLabs.Spawn.Vulkan.Target";
				Console.WriteLine($"Creating {creator.TypeName} files.");
				creator.Create();
				Console.WriteLine($"Created {creator.NumberCreated} {creator.TypeName} files.");
			}
		}

		private IEnumerable<ICreator> Creators { get; }

		private XElement Registry { get; set; }

		private ISpawnService Spawn { get; }

		private IVulkanSpec Rules { get; }
	}
}
