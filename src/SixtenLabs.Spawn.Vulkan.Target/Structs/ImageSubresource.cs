using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageSubresource
    {
        public ImageAspectFlags aspectMask;
        public uint mipLevel;
        public uint arrayLayer;
    }
}