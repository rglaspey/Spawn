using SimpleInjector;
using SixtenLabs.Spawn.Utility;
using System.Collections.Generic;
using System.Reflection;

namespace SixtenLabs.Spawn.Vulkan.Generator
{
	public class VulkanBootstrapper
	{
		public VulkanBootstrapper()
		{
		}

		private void Register()
		{
			SimpleContainer = new Container();

			SimpleContainer.RegisterSingleton<ISpawn, Spawn>();
			SimpleContainer.RegisterSingleton<IGeneratorSettings, VulkanSettings>();
			SimpleContainer.RegisterSingleton<XmlFileLoader>();
			SimpleContainer.RegisterSingleton<VulkanGenerator>();
			SimpleContainer.RegisterSingleton<ICreatorRules, VulkanRules>();
			SimpleContainer.RegisterSingleton<ICodeGenerator, CSharpGenerator>();

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
			var spawnAssembly = Assembly.GetAssembly(typeof(BaseCreator));
			var vulkanAssembly = Assembly.GetAssembly(typeof(VulkanRules));
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
