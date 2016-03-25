using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DebugReportEXT : int
    {
        DebugReportInformationBitExt = 1 << 0,
        DebugReportWarningBitExt = 1 << 1,
        DebugReportPerformanceWarningBitExt = 1 << 2,
        DebugReportErrorBitExt = 1 << 3,
        DebugReportDebugBitExt = 1 << 4
    }
}