using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandPoolCreateFlags
    {
        /// <summary>
                /// Command buffers have a short lifetime
                /// </summary>
        CommandPoolCreateTransientBit = 0,
        /// <summary>
                /// Command buffers may release their memory individually
                /// </summary>
        CommandPoolCreateResetCommandBufferBit = 1
    }
}