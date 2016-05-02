using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ImageBlit
    {
        public ImageSubresourceLayers srcSubresource;
        public Offset3D[] srcOffsets;
        public ImageSubresourceLayers dstSubresource;
        public Offset3D[] dstOffsets;
    }
}