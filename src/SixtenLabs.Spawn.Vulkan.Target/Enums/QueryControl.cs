using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryControl : int
    {
        QueryControlPreciseBit = 1 << 0
    }
}