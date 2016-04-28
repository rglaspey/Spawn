using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferCreateFlags
    {
        /// <summary>
                /// Buffer should support sparse backing
                /// </summary>
        BufferCreateSparseBindingBit = 0,
        /// <summary>
                /// Buffer should support sparse backing with partial residency
                /// </summary>
        BufferCreateSparseResidencyBit = 1,
        /// <summary>
                /// Buffer should support constent data access to physical memory ranges mapped into multiple locations of sparse buffers
                /// </summary>
        BufferCreateSparseAliasedBit = 2
    }
}