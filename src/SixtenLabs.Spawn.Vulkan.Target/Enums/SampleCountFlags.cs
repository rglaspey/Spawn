using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SampleCountFlags
    {
        /// <summary>
                /// Sample count 1 supported
                /// </summary>
        SampleCount1Bit = 0,
        /// <summary>
                /// Sample count 2 supported
                /// </summary>
        SampleCount2Bit = 1,
        /// <summary>
                /// Sample count 4 supported
                /// </summary>
        SampleCount4Bit = 2,
        /// <summary>
                /// Sample count 8 supported
                /// </summary>
        SampleCount8Bit = 3,
        /// <summary>
                /// Sample count 16 supported
                /// </summary>
        SampleCount16Bit = 4,
        /// <summary>
                /// Sample count 32 supported
                /// </summary>
        SampleCount32Bit = 5,
        /// <summary>
                /// Sample count 64 supported
                /// </summary>
        SampleCount64Bit = 6
    }
}