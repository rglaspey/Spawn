using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandPoolResetFlags
    {
        /// <summary>
                /// Release resources owned by the pool
                /// </summary>
        CommandPoolResetReleaseResourcesBit = 0
    }
}