using SimpleInjector;
using SixtenLabs.Spawn;
using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Vulkan.Generator
{
	public class VulkanBootstrapper
	{
		public VulkanBootstrapper()
		{
		}

		private void Register()
		{
			SimpleContainer = new Container();

			SimpleContainer.RegisterSingleton<ISpawnService, SpawnService>();
			SimpleContainer.RegisterSingleton<IGeneratorSettings, VulkanSettings>();
			SimpleContainer.RegisterSingleton<XmlFileLoader<registry>>();
			SimpleContainer.RegisterSingleton<VulkanGenerator>();
			SimpleContainer.RegisterSingleton<ISpawnSpec<registry>, VulkanSpec>();
			SimpleContainer.RegisterSingleton<ICodeGenerator, CSharpGenerator>();
			SimpleContainer.RegisterSingleton<IXmlSerializer, DynamicToXmlSerializer>();
			SimpleContainer.RegisterSingleton<ITypeMapper, VulkanTypeMapper>();

			var creatorTypes = SimpleContainer.GetTypesToRegister(typeof(ICreator), Assemblies);

			foreach (var creatorType in creatorTypes)
			{
				SimpleContainer.RegisterSingleton(creatorType, creatorType);
			}

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
