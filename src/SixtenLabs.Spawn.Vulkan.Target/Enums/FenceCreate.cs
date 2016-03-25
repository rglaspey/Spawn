using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum FenceCreate : int
    {
        FenceCreateSignaledBit = 1 << 0
    }
}