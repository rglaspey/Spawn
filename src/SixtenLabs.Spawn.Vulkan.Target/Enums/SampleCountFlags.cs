using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SampleCountFlags
    {
        SampleCount1Bit = 0,
        SampleCount2Bit = 1,
        SampleCount4Bit = 2,
        SampleCount8Bit = 3,
        SampleCount16Bit = 4,
        SampleCount32Bit = 5,
        SampleCount64Bit = 6
    }
}