using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ClearAttachment
    {
        public ImageAspectFlags aspectMask;
        public uint colorAttachment;
        public ClearValue clearValue;
    }
}