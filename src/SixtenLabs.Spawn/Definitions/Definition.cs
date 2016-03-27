using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Base definition. Holds all common functionality for concrete definitions
	/// </summary>
  public abstract class Definition
  {
    public Definition()
    {
    }

		/// <summary>
		/// Final name to use.
		/// </summary>
    public string Name { get; set; }

		/// <summary>
		/// Original Name found in the spec that is being parsed
		/// </summary>
		public string SpecName { get; set; }
  }
}
