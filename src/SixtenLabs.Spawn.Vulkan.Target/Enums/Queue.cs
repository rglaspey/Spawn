using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum Queue : int
    {
        QueueGraphicsBit = 1 << 0,
        QueueComputeBit = 1 << 1,
        QueueTransferBit = 1 << 2,
        QueueSparseBindingBit = 1 << 3
    }
}