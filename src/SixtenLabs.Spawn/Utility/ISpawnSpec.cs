namespace SixtenLabs.Spawn.Utility
{
	public interface ISpawnSpec<T> where T : class
	{
		void ProcessRegistry();

		T SpecTree { get; }

		SpecTypeDefinition FindTypeDefinition(string specName);

		void AddSpecType(string specName, string translatedName);

		int SpecTypeCount { get; }
	}
}
