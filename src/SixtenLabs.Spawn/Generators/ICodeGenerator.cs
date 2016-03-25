namespace SixtenLabs.Spawn
{
	public interface ICodeGenerator
	{
		string GenerateEnum(OutputDefinition outputDefinition, EnumDefinition enumDefinition);
	}
}
