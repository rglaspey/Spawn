using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct AllocationCallbacks
    {
        public IntPtr pUserData;
        public IntPtr pfnAllocation;
        public IntPtr pfnReallocation;
        public IntPtr pfnFree;
        public IntPtr pfnInternalAllocation;
        public IntPtr pfnInternalFree;
    }
}