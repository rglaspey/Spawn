using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageFormatProperties
    {
        public Extent3D maxExtent;
        public uint maxMipLevels;
        public uint maxArrayLayers;
        public SampleCountFlags sampleCounts;
        public ulong maxResourceSize;
    }
}