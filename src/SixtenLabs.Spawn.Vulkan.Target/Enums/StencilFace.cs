using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum StencilFace : int
    {
        StencilFaceFrontBit = 1 << 0,
        StencilFaceBackBit = 1 << 1,
        StencilFrontAndBack = 1 << 0x00000003
    }
}