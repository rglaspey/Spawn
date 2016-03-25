namespace SixtenLabs.Spawn.Utility
{
	public interface ICreator
	{
		void MapTypes();

		void Build();

		void Create();

		string TargetSolution { get; set; }

		string TargetNamespace { get; set; }

		int NumberCreated { get; }

		string Name { get; }

		string TypeName { get; }
	}
}
