namespace SixtenLabs.Spawn
{
	public interface ISpawnSpec<T> where T : class
	{
		void ProcessRegistry();

		T SpecTree { get; }

		SpecTypeDefinition FindTypeDefinition(string specName);

		string GetTranslatedName(string specName);

		string GetTranslatedChildName(string specName, string childSpecName);

		void AddSpecTypeDefinition(SpecTypeDefinition specTypeDefinition);

		int SpecTypeCount { get; }
	}
}
