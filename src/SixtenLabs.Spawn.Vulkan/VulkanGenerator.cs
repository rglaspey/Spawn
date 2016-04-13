﻿using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class VulkanGenerator
	{
		public VulkanGenerator(IEnumerable<ICreator> creators, ITypeMapper typeMapper, ISpawnService spawn, ISpawnSpec<registry> spawnSpec)
		{
			Creators = creators;
			TypeMapper = typeMapper;
			Spawn = spawn;
			SpawnSpec = spawnSpec;
		}

		private void SetupGeneratedComments()
		{
			GeneratedComments.Add("*** Do Not Edit ***");
			GeneratedComments.Add("This file was generated by the Spawn Code Generator.");
			GeneratedComments.Add("https://github.com/SixtenLabs/Spawn");
			GeneratedComments.Add(string.Empty);
			GeneratedComments.Add("Generated from the vk.xml registry file from Khronos Group.");
			GeneratedComments.Add("https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/1.0/src/spec/vk.xml");
			GeneratedComments.Add(string.Empty);
		}

		public void Initialize()
		{
			Spawn.Initialize(@"C:\Users\pglas\Documents\GitHub\SixtenLabs\Spawn\Spawn.sln");
			SpawnSpec.ProcessRegistry();
			SetupGeneratedComments();
			Console.WriteLine("Spawn Vulkan Generator Initialized, processing has begun.");
		}

		public void MapTypes()
		{
			var mappedTypeCount = TypeMapper.MapTypes();

			Console.WriteLine($"Mapped {mappedTypeCount} types.");
		}

		public void Rewrite()
		{
			var orderedCreators = Creators.OrderBy(x => x.Order);

			foreach (var creator in orderedCreators)
			{
				Console.WriteLine($"Rewriting {creator.TypeName} files.");
				var count = creator.Rewrite();
				Console.WriteLine($"Rewrote {count} {creator.TypeName} files.");
			}
		}

		public void Build()
		{
			foreach (var creator in Creators)
			{
				Console.WriteLine($"Building {creator.TypeName} definition files.");
				var count = creator.Build();
				Console.WriteLine($"Building {count} {creator.TypeName} definition files.");
			}
		}

		public void Generate()
		{
			foreach (var creator in Creators)
			{
				creator.TargetSolution = "SixtenLabs.Spawn.Vulkan.Target";
				creator.TargetNamespace = "SixtenLabs.Spawn.Vulkan.Target";
				creator.GeneratedComments.AddRange(GeneratedComments);
				Console.WriteLine($"Creating {creator.TypeName} files.");
				var count = creator.Create();
				Console.WriteLine($"Created {count} {creator.TypeName} files.");
			}
		}

		public void Start()
		{
			Initialize();
			MapTypes();
			Rewrite();
			Build();
			//Generate();
		}

		private IEnumerable<ICreator> Creators { get; }

		private XElement Registry { get; set; }

		private ISpawnService Spawn { get; }

		private ISpawnSpec<registry> SpawnSpec { get; }

		private List<string> GeneratedComments { get; } = new List<string>();

		private ITypeMapper TypeMapper { get; }
	}
}
