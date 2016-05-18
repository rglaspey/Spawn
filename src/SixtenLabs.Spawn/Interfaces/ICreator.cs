using AutoMapper;
using System.Collections.Generic;

namespace SixtenLabs.Spawn
{
	public interface ICreator
	{
		/// <summary>
		/// Rewrite any names on this pass
		/// </summary>
		int Rewrite();

		/// <summary>
		/// Build the definition files
		/// </summary>
		int Build(IMapper mapper);

		/// <summary>
		/// Create Code files for all the definition files.
		/// </summary>
		int Create();

		string TargetSolution { get; set; }

		string TargetNamespace { get; set; }

		List<string> GeneratedComments { get; }

		string TypeName { get; }

		/// <summary>
		/// The name of the creator, for displaying in the console 
		/// while generating code.
		/// </summary>
		string Name { get; }

		int Order { get; }

		bool Off { get; set; }
	}
}
