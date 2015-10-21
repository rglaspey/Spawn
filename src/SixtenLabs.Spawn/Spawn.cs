using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class Spawn : ISpawn
	{
		public Spawn()
		{

		}

		private void Discovery()
		{

		}

		private void OpenWorkspace()
		{
			Workspace = MSBuildWorkspace.Create();
			Solution = Workspace.OpenSolutionAsync(SolutionPath).Result;
		}

		private MSBuildWorkspace Workspace { get; set; }

		public string SolutionPath { get; set; }

		private Solution Solution { get; set; }

		public string SourceProject { get; set; }

		public string TargetProject { get; set; }
		
		public IEnumerable<string> FilesToGenerate { get; }
	}
}
