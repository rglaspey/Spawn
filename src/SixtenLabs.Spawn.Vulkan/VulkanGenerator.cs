﻿using SixtenLabs.Spawn.Utility;
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
		public VulkanGenerator(IEnumerable<ICreator> creators, ISpawn spawn, ICreatorRules rules)
		{
			Creators = creators;
			Spawn = spawn;
			Rules = rules;
		}

		public void Initialize()
		{
			Spawn.Intialize("../../../../../Spawn/Spawn.sln");
			Rules.ProcessRegistry();
		}

		public void MapTypes()
		{
			foreach (var creator in Creators)
			{
				Console.WriteLine($"Mapping {creator.TypeName} files.");
				creator.MapTypes();
				Console.WriteLine($"Mapped {creator.NumberCreated} {creator.TypeName} files.");
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

		private ISpawn Spawn { get; }

		private ICreatorRules Rules { get; }
	}
}