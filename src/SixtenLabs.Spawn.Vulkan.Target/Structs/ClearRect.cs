using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ClearRect
    {
        public Rect2D rect;
        public uint baseArrayLayer;
        public uint layerCount;
    }
}