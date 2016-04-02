using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum CompositeAlphaFlagBitsKHR
  {
    COMPOSITE_ALPHA_OPAQUE_BIT_KHR = 0,

    COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR = 1,

    COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR = 2,

    COMPOSITE_ALPHA_INHERIT_BIT_KHR = 3
  }
}