using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandBufferUsageFlags
    {
        CommandBufferUsageOneTimeSubmitBit = 0,
        CommandBufferUsageRenderPassContinueBit = 1,
        CommandBufferUsageSimultaneousUseBit = 2
    }
}