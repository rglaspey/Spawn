using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferCreate : int
    {
        BufferCreateSparseBindingBit = 1 << 0,
        BufferCreateSparseResidencyBit = 1 << 1,
        BufferCreateSparseAliasedBit = 1 << 2
    }
}