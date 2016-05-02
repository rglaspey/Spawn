using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PhysicalDeviceProperties
    {
        public uint apiVersion;
        public uint driverVersion;
        public uint vendorID;
        public uint deviceID;
        public PhysicalDeviceType deviceType;
        public char[] deviceName;
        public byte[] pipelineCacheUUID;
        public PhysicalDeviceLimits limits;
        public PhysicalDeviceSparseProperties sparseProperties;
    }
}