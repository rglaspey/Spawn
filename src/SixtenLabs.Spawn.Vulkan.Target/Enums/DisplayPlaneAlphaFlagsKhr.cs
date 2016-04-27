using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DisplayPlaneAlphaFlagsKhr
    {
        DisplayPlaneAlphaOpaqueBitKhr = 0,
        DisplayPlaneAlphaGlobalBitKhr = 1,
        DisplayPlaneAlphaPerPixelBitKhr = 2,
        DisplayPlaneAlphaPerPixelPremultipliedBitKhr = 3
    }
}