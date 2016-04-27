using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryResultFlags
    {
        QueryResult64Bit = 0,
        QueryResultWaitBit = 1,
        QueryResultWithAvailabilityBit = 2,
        QueryResultPartialBit = 3
    }
}