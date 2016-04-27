using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DebugReportFlagsExt
    {
        DebugReportInformationBitExt = 0,
        DebugReportWarningBitExt = 1,
        DebugReportPerformanceWarningBitExt = 2,
        DebugReportErrorBitExt = 3,
        DebugReportDebugBitExt = 4
    }
}