using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DeviceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint queueCreateInfoCount;
        public DeviceQueueCreateInfo pQueueCreateInfos;
        public uint enabledLayerCount;
        public char ppEnabledLayerNames;
        public uint enabledExtensionCount;
        public char ppEnabledExtensionNames;
        public PhysicalDeviceFeatures pEnabledFeatures;
    }
}