using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DisplayPlaneAlphaKHR : int
    {
        DisplayPlaneAlphaOpaqueBitKhr = 1 << 0,
        DisplayPlaneAlphaGlobalBitKhr = 1 << 1,
        DisplayPlaneAlphaPerPixelBitKhr = 1 << 2,
        DisplayPlaneAlphaPerPixelPremultipliedBitKhr = 1 << 3
    }
}