using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DeviceQueueCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint queueFamilyIndex;
        public uint queueCount;
        public float pQueuePriorities;
    }
}