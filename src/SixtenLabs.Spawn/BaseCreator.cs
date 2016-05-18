using AutoMapper;
using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public abstract class BaseCreator<T, U> : ICreator where T : class
	{
		public BaseCreator(ICodeGenerator generator, ISpawnSpec<T> spawnSpec, string name, int order)
		{
			Generator = generator;
			VulkanSpec = spawnSpec;
			Order = order;
			Name = name;
		}

		public abstract int Rewrite();

		public abstract int Build(IMapper mapper);

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

		/// <summary>
		/// The name of the creator, for displaying in the console 
		/// while generating code.
		/// </summary>
		public string Name { get; }

		protected ISpawnSpec<T> VulkanSpec { get; }

		public int Order { get; set; }

		/// <summary>
		/// Used to populate a generated code message in the top level type comments.
		/// </summary>
		public List<string> GeneratedComments { get; } = new List<string>();

		protected IList<U> Definitions { get; } = new List<U>();

		/// <summary>
		/// This is used to turn off or on a creator.
		/// </summary>
		public bool Off { get; set; }
	}
}
