using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public ImageCreateFlags flags;
        public ImageType imageType;
        public Format format;
        public Extent3D extent;
        public uint mipLevels;
        public uint arrayLayers;
        public SampleCountFlags samples;
        public ImageTiling tiling;
        public ImageUsageFlags usage;
        public SharingMode sharingMode;
        public uint queueFamilyIndexCount;
        public uint pQueueFamilyIndices;
        public ImageLayout initialLayout;
    }
}