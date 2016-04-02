using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum MemoryHeapFlags
  {
    /// <summary> 
    /// If set, heap represents device memory
    /// </summary> 
    MEMORY_HEAP_DEVICE_LOCAL_BIT = 0
  }
}