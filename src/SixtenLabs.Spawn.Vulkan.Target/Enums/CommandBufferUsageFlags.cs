using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandBufferUsageFlags
    {
        CommandBufferUsageOneTimeSubmitBit = 0,
        CommandBufferUsageRenderPassContinueBit = 1,
        /// <summary>
                /// Command buffer may be submitted/executed more than once simultaneously
                /// </summary>
        CommandBufferUsageSimultaneousUseBit = 2
    }
}