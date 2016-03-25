using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SampleCount : int
    {
        SampleCount1Bit = 1 << 0,
        SampleCount2Bit = 1 << 1,
        SampleCount4Bit = 1 << 2,
        SampleCount8Bit = 1 << 3,
        SampleCount16Bit = 1 << 4,
        SampleCount32Bit = 1 << 5,
        SampleCount64Bit = 1 << 6
    }
}