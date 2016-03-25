using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CullMode : int
    {
        CullModeNone = 1 << 0,
        CullModeFrontBit = 1 << 0,
        CullModeBackBit = 1 << 1,
        CullModeFrontAndBack = 1 << 0x00000003
    }
}