﻿using AutoMapper;
using SimpleInjector;
using SixtenLabs.Spawn;
using SixtenLabs.Spawn.Generator.CSharp;
using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SixtenLabs.Vulkan.Generator
{
	public class VulkanBootstrapper
	{
		public VulkanBootstrapper()
		{
		}

		private void RegisterAutomapper()
		{
			var profileTypeInstances = SimpleContainer.GetTypesToRegister(typeof(Profile), Assemblies).Select(t => (Profile)Activator.CreateInstance(t));

			var config = new MapperConfiguration(cfg =>
			{
				foreach (var profile in profileTypeInstances)
				{
					cfg.AddProfile(profile);
				}
			});

			SimpleContainer.RegisterSingleton<MapperConfiguration>(config);
			SimpleContainer.Register<IMapper>(() => config.CreateMapper(SimpleContainer.GetInstance));

			Mapper.AssertConfigurationIsValid();
		}

		private void Register()
		{
			SimpleContainer = new Container();

			SimpleContainer.RegisterSingleton<ISpawnService, SpawnService>();
			SimpleContainer.RegisterSingleton<IGeneratorSettings, VulkanSettings>();
			SimpleContainer.RegisterSingleton<XmlFileLoader<registry>>();
			SimpleContainer.Register<VulkanGenerator>();
			SimpleContainer.RegisterSingleton<ISpawnSpec<registry>, VulkanSpec>();
			SimpleContainer.RegisterSingleton<ICodeGenerator, CSharpGenerator>();
			SimpleContainer.RegisterSingleton<IXmlSerializer, SpawnXmlSerializer>();

			var creatorTypes = SimpleContainer.GetTypesToRegister(typeof(ICreator), Assemblies);

			foreach (var creatorType in creatorTypes)
			{
				SimpleContainer.RegisterSingleton(creatorType, creatorType);
			}
			
			RegisterAutomapper();

			SimpleContainer.RegisterCollection<ICreator>(Assemblies);
		}

		private void Verify()
		{
			SimpleContainer.Verify();
		}

		public void Bootstrap()
		{
			SelectAssemblies();
			Register();
			Verify();
		}

		protected void SelectAssemblies()
		{
			var spawnAssembly = Assembly.GetAssembly(typeof(ISpawnService));
			var vulkanAssembly = Assembly.GetAssembly(typeof(VulkanSpec));
			var generatorAssembly = Assembly.GetAssembly(typeof(Program));

			Assemblies.Add(spawnAssembly);
			Assemblies.Add(vulkanAssembly);
			Assemblies.Add(generatorAssembly);
		}

		public VulkanGenerator GetRoot()
		{
			return SimpleContainer.GetInstance<VulkanGenerator>();
		}

		private static Container SimpleContainer { get; set; }

		private List<Assembly> Assemblies { get; set; } = new List<Assembly>();
	}
}
