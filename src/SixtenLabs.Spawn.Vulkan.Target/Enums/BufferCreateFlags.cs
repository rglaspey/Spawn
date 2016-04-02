using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum BufferCreateFlags
  {
    /// <summary> 
    /// Buffer should support sparse backing
    /// </summary> 
    BUFFER_CREATE_SPARSE_BINDING_BIT = 0,

    /// <summary> 
    /// Buffer should support sparse backing with partial residency
    /// </summary> 
    BUFFER_CREATE_SPARSE_RESIDENCY_BIT = 1,

    /// <summary> 
    /// Buffer should support constent data access to physical memory ranges mapped into multiple locations of sparse buffers
    /// </summary> 
    BUFFER_CREATE_SPARSE_ALIASED_BIT = 2
  }
}