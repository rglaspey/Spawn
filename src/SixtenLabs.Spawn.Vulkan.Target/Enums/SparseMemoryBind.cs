using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SparseMemoryBind : int
    {
        SparseMemoryBindMetadataBit = 1 << 0
    }
}