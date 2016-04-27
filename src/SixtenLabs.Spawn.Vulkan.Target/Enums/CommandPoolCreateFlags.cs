using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CommandPoolCreateFlags
    {
        CommandPoolCreateTransientBit = 0,
        CommandPoolCreateResetCommandBufferBit = 1
    }
}