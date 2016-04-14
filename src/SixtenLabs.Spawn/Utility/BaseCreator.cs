using System.Collections.Generic;

namespace SixtenLabs.Spawn.Utility
{
	public abstract class BaseCreator<T, U> : ICreator where T : class
	{
		public BaseCreator(ICodeGenerator generator, ISpawnSpec<T> spawnSpec, int order)
		{
			Generator = generator;
			VulkanSpec = spawnSpec;
			Order = order;
		}

		public abstract int Rewrite();

		public abstract int Build();

		public abstract int Create();

		protected ICodeGenerator Generator { get; }

		public string TargetSolution { get; set; }

		public string TargetNamespace { get; set; }

		public string TypeName
		{
			get
			{
				return typeof(U).Name;
			} 
		}

		protected ISpawnSpec<T> VulkanSpec { get; }

		public int Order { get; set; }

		/// <summary>
		/// Used to populate a generated code message in the top level type comments.
		/// </summary>
		public List<string> GeneratedComments { get; } = new List<string>();

		protected IList<U> Definitions { get; } = new List<U>();
	}
}
