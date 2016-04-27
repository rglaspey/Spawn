using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueueFlags
    {
        QueueGraphicsBit = 0,
        QueueComputeBit = 1,
        QueueTransferBit = 2,
        QueueSparseBindingBit = 3
    }
}