﻿using System.IO;

namespace SixtenLabs.Spawn.Utility
{
	/// <summary>
	/// The code generation is controlled from this settings class.
	/// </summary>
	public abstract class GeneratorSettings : IGeneratorSettings
	{
		public GeneratorSettings(string targetSolutionName, string rootNamespace, string fileName, string webUri, string version, XmlLoadMethod loadMethod = XmlLoadMethod.FromUri)
		{
			TargetSolutionName = targetSolutionName;
			RootNameSpace = rootNamespace;
			FileName = fileName;
			WebUri = webUri;
			LoadMethod = loadMethod;

			SetRootDirectory();
		}

		private void SetRootDirectory()
		{
			DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

			while (directory != null && !File.Exists(Path.Combine(directory.FullName, TargetSolutionName)))
			{
				directory = directory.Parent;

				if (directory != null)
				{
					RootDirectory = directory.FullName;
				}
			}
		}

		public XmlLoadMethod LoadMethod { get; }

		public string FileName { get; }

		public string WebUri { get; }

		public string RootDirectory { get; set; }

		public string RootNameSpace { get; }

		public string TargetSolutionName { get; }

		public string VersionToGenerate { get; }
	}
}
