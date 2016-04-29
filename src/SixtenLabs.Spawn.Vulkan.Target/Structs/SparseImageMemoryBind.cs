using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseImageMemoryBind
    {
        public ImageSubresource subresource;
        public Offset3D offset;
        public Extent3D extent;
        public DeviceMemory memory;
        public ulong memoryOffset;
        public SparseMemoryBindFlags flags;
    }
}