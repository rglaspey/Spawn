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

    public string Name { get; set; }
  }
}
