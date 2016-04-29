using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct QueueFamilyProperties
    {
        public QueueFlags queueFlags;
        public uint queueCount;
        public uint timestampValidBits;
        public Extent3D minImageTransferGranularity;
    }
}