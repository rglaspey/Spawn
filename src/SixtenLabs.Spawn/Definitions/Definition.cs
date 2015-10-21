using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Base definition. Holds all common functionality for concrete definitions
	/// </summary>
  public abstract class Definition
  {
    #region Constructors

    public Definition(string name)
    {
      Name = name;
    }

    #endregion

    #region Properties

    public string Name { get; }

	  #endregion
  }
}
