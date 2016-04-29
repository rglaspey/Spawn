using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageViewCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public Image image;
        public ImageViewType viewType;
        public Format format;
        public ComponentMapping components;
        public ImageSubresourceRange subresourceRange;
    }
}