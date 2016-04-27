using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferCreateFlags
    {
        BufferCreateSparseBindingBit = 0,
        BufferCreateSparseResidencyBit = 1,
        BufferCreateSparseAliasedBit = 2
    }
}