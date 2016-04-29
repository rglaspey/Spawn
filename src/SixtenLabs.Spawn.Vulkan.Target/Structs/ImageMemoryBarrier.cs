using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageMemoryBarrier
    {
        public StructureType sType;
        public IntPtr pNext;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public ImageLayout oldLayout;
        public ImageLayout newLayout;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public Image image;
        public ImageSubresourceRange subresourceRange;
    }
}