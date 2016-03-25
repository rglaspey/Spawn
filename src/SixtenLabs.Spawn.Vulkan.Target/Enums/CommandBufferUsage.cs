using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandBufferUsage : int
    {
        CommandBufferUsageOneTimeSubmitBit = 1 << 0,
        CommandBufferUsageRenderPassContinueBit = 1 << 1,
        CommandBufferUsageSimultaneousUseBit = 1 << 2
    }
}