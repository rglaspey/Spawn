using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Use this class to define an output.
	/// </summary>
	public class OutputDefinition : Definition
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
		public NamespaceDefinition Namespace { get; private set; }


		public IList<TypeDefinition> TypeDefinitions { get; } = new List<TypeDefinition>();

		public string TargetSolution { get; set; }
	}
}
