using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum CommandPoolResetFlags
  {
    /// <summary> 
    /// Release resources owned by the pool
    /// </summary> 
    COMMAND_POOL_RESET_RELEASE_RESOURCES_BIT = 0
  }
}