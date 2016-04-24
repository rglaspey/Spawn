namespace SixtenLabs.Spawn
{
	public interface ICodeGenerator
	{
		void GenerateCodeFile<T>(IOutputDefinition<T> outputDefinition) where T : IDefinition;
	}
}
