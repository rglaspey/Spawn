using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum QueryControlFlags
  {
    /// <summary> 
    /// Require precise results to be collected by the query
    /// </summary> 
    QUERY_CONTROL_PRECISE_BIT = 0
  }
}