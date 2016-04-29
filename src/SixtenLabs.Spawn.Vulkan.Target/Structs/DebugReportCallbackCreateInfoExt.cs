using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DebugReportCallbackCreateInfoExt
    {
        public StructureType sType;
        public IntPtr pNext;
        public DebugReportFlagsExt flags;
        public IntPtr pfnCallback;
        public IntPtr pUserData;
    }
}