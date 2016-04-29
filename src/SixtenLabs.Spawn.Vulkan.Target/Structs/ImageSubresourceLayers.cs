using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageSubresourceLayers
    {
        public ImageAspectFlags aspectMask;
        public uint mipLevel;
        public uint baseArrayLayer;
        public uint layerCount;
    }
}