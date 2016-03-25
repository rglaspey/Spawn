using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandBufferReset : int
    {
        CommandBufferResetReleaseResourcesBit = 1 << 0
    }
}