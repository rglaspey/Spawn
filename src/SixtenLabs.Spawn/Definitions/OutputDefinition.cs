using System.Collections.Generic;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Use this class to define an output.
	/// </summary>
	public class OutputDefinition<T> where T : TypeDefinition
	{
		public OutputDefinition()
		{
		}

		/// <summary>
		/// Add the names of the dlls to use to create using statements for this output
		/// </summary>
		/// <param name="names"></param>
		public void AddStandardUsingDirective(string dllName)
		{
			var usingDefinition = new UsingDirectiveDefinition() { Name = dllName };
			Usings.Add(usingDefinition);
		}

		/// <summary>
		/// Add the names of the dlls to use to create using statements for this output
		/// </summary>
		/// <param name="names"></param>
		public void AddStaticUsingDirective(string dllName)
		{
			var usingDefinition = new UsingDirectiveDefinition() { Name = dllName, IsStatic = true };
			Usings.Add(usingDefinition);
		}

		/// <summary>
		/// Add the names of the dlls to use to create using statements for this output
		/// </summary>
		/// <param name="names"></param>
		public void AddAliasedUsingDirective(string dllName, string alias)
		{
			var usingDefinition = new UsingDirectiveDefinition() { Name = dllName, Alias = alias };
			Usings.Add(usingDefinition);
		}

		public void AddNamespace(string @namespace)
		{
			Namespace = new NamespaceDefinition() { Name = @namespace };
    }


		/// <summary>
		/// The names of the dlls to use to create using statements for this output
		/// </summary>
		public IList<UsingDirectiveDefinition> Usings { get; } = new List<UsingDirectiveDefinition>();

		/// <summary>
		/// The namesapce of the output.
		/// </summary>
		public NamespaceDefinition Namespace { get; set; }

		/// <summary>
		/// The content to insert inside the namespace declaration.
		/// Typically a single enum, class, struct, etc..
		/// Supports multiples of the same type ie.. generate a single file for many enums.
		/// </summary>
		public IList<T> TypeDefinitions { get; } = new List<T>();

		public string TargetSolution { get; set; }

		public string FileName { get; set; }

		public string TemplateName { get; set; }

		public IList<string> CommentLines { get; } = new List<string>();

		public string OutputDirectory { get; set; }
	}
}
