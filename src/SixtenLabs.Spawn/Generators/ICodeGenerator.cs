namespace SixtenLabs.Spawn
{
	public interface ICodeGenerator
	{
		void GenerateCodeFile<T>(OutputDefinition<T> outputDefinition) where T : Definition;
	}
}
