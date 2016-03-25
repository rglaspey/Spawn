﻿using Microsoft.CodeAnalysis;
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
			var newSolution = Workspace.CurrentSolution;
			var project = newSolution.Projects.First(x => x.Name == projectName);

			return project;
		}

		private void ApplyChanges(Solution solution)
		{
			var result = Workspace.TryApplyChanges(solution);

			if(!result)
			{
				throw new InvalidOperationException("Could not apply changes to workspace...why not?");
			}
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

			Document newDocument = null;

			if (document != null)
			{
				newDocument = document.WithText(SourceText.From(contents));
			}
			else
			{
				newDocument = project.AddDocument(newFileName, contents, folders, filePath);
			}

			ApplyChanges(newDocument.Project.Solution);
    }

		private MSBuildWorkspace Workspace { get; set; }

		private string SolutionPath { get; set; }

		private Solution Solution { get; set; }
	}
}