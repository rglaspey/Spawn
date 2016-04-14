namespace SixtenLabs.Spawn.Utility
{
	public abstract class BaseTypeMapper<T> : ITypeMapper where T : class
	{
		public BaseTypeMapper(ISpawnSpec<T> spawnSpec)
		{
			SpawnSpec = spawnSpec;
		}

		public abstract int MapTypes();

		protected ISpawnSpec<T> SpawnSpec { get; }
	}
}
