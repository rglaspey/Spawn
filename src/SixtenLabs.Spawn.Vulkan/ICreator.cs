namespace SixtenLabs.Spawn.Utility
{
	public interface ICreator
	{
		/// <summary>
		/// Map all the types from the registry spec
		/// </summary>
		void MapTypes();

		/// <summary>
		/// Rewrite any names on this pass
		/// </summary>
		void Rewrite();

		/// <summary>
		/// Build the definition files
		/// </summary>
		void Build();

		/// <summary>
		/// Create Code files for all the definition files.
		/// </summary>
		void Create();

		string TargetSolution { get; set; }

		string TargetNamespace { get; set; }

		int NumberCreated { get; }

		string Name { get; }

		string TypeName { get; }

		int Order { get; }
	}
}
