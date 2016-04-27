using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum StencilFaceFlags
    {
        StencilFaceFrontBit = 0,
        StencilFaceBackBit = 1,
        StencilFrontAndBack = 0x00000003
    }
}