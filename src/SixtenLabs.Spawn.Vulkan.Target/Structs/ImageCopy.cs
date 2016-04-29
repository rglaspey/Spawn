using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageCopy
    {
        public ImageSubresourceLayers srcSubresource;
        public Offset3D srcOffset;
        public ImageSubresourceLayers dstSubresource;
        public Offset3D dstOffset;
        public Extent3D extent;
    }
}