using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct BufferImageCopy
    {
        public ulong bufferOffset;
        public uint bufferRowLength;
        public uint bufferImageHeight;
        public ImageSubresourceLayers imageSubresource;
        public Offset3D imageOffset;
        public Extent3D imageExtent;
    }
}