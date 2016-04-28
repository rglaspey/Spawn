using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandBufferResetFlags
    {
        /// <summary>
                /// Release resources owned by the buffer
                /// </summary>
        CommandBufferResetReleaseResourcesBit = 0
    }
}