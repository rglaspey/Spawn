namespace SixtenLabs.Spawn
{
	public interface IGeneratorSettings
	{
		XmlLoadMethod LoadMethod { get; }

		string FileName { get; }

		string WebUri { get; }

		string RootDirectory { get; set; }

		string RootNamespace { get; }

		string TargetSolutionName { get; }

		string VersionToGenerate { get; }
	}
}
