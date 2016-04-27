using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CullModeFlags
    {
        CullModeNone = 0,
        CullModeFrontBit = 0,
        CullModeBackBit = 1,
        CullModeFrontAndBack = 0x00000003
    }
}