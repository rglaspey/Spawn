using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SparseMemoryBindFlags
    {
        /// <summary>
                /// Operation binds resource metadata to memory
                /// </summary>
        SparseMemoryBindMetadataBit = 0
    }
}