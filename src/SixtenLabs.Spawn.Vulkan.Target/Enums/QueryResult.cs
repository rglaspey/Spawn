using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryResult : int
    {
        QueryResult64Bit = 1 << 0,
        QueryResultWaitBit = 1 << 1,
        QueryResultWithAvailabilityBit = 1 << 2,
        QueryResultPartialBit = 1 << 3
    }
}