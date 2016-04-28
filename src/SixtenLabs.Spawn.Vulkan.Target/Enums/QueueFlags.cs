using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueueFlags
    {
        /// <summary>
                /// Queue supports graphics operations
                /// </summary>
        QueueGraphicsBit = 0,
        /// <summary>
                /// Queue supports compute operations
                /// </summary>
        QueueComputeBit = 1,
        /// <summary>
                /// Queue supports transfer operations
                /// </summary>
        QueueTransferBit = 2,
        /// <summary>
                /// Queue supports sparse resource memory management operations
                /// </summary>
        QueueSparseBindingBit = 3
    }
}