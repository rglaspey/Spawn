using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
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

		private void OpenWorkspace()
		{
			Workspace = MSBuildWorkspace.Create();
			Solution = Workspace.OpenSolutionAsync(SolutionPath).Result;
		}

		private Project GetProject(string projectName)
		{
			var newSolution = Solution;
			var project = newSolution.Projects.First(x => x.Name == projectName);

			return project;
		}

		private void ApplyChanges(Solution solution)
		{
			Workspace.TryApplyChanges(solution);
		}

		/// <summary>
		/// Before generating any code, intialize the workspace with 
		/// the solution file.
		/// </summary>
		/// <param name="solutionPath"></param>
		public void Intialize(string solutionPath)
		{
			SolutionPath = solutionPath;
			OpenWorkspace();
		}

		/// <summary>
		/// Create a file in the target project with generated code from the passed in SyntaxNode
		/// </summary>
		/// <param name="targetProject"></param>
		/// <param name="newFileName"></param>
		/// <param name="contents"></param>
		public void AddDocumentToProject(string targetProject, string newFileName, string contents, IEnumerable<string> folders = null, string filePath = null)
		{
			var project = GetProject(targetProject);

			var document = project.Documents.Where(x => x.Name == $"{newFileName}.cs").FirstOrDefault();

			if (document != null)
			{
				document = document.WithText(SourceText.From(contents));
			}
			else
			{
				document = project.AddDocument(newFileName, contents, folders, filePath);
			}

			project = document.Project;
			var solution = project.Solution;

			ApplyChanges(solution);
    }

		private MSBuildWorkspace Workspace { get; set; }

		private string SolutionPath { get; set; }

		private Solution Solution { get; set; }
	}
}
