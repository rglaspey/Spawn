namespace SixtenLabs.Spawn.Utility
{
	public interface IGeneratorSettings
	{
		XmlLoadMethod LoadMethod { get; }

		string FileName { get; }

		string WebUri { get; }

		string RootDirectory { get; set; }

		string RootNameSpace { get; }

		string TargetSolutionName { get; }

		string VersionToGenerate { get; }
	}
}
