using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define a region directive
	/// </summary>
	public class RegionDefinition : Definition
	{
		#region Constructors

		public RegionDefinition(string name, bool useRegionDirective)
      : base(name)
    {
      UseRegionDirective = useRegionDirective;
		}

    #endregion

    #region Properties

    public bool UseRegionDirective { get; }

    #endregion
  }
}
