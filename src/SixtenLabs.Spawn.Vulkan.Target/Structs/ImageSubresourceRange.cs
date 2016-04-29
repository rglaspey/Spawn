using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageSubresourceRange
    {
        public ImageAspectFlags aspectMask;
        public uint baseMipLevel;
        public uint levelCount;
        public uint baseArrayLayer;
        public uint layerCount;
    }
}