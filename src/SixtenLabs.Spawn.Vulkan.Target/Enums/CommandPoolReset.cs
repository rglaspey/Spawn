using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandPoolReset : int
    {
        CommandPoolResetReleaseResourcesBit = 1 << 0
    }
}