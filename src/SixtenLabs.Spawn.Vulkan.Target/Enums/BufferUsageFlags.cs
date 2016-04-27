using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferUsageFlags
    {
        BufferUsageTransferSrcBit = 0,
        BufferUsageTransferDstBit = 1,
        BufferUsageUniformTexelBufferBit = 2,
        BufferUsageStorageTexelBufferBit = 3,
        BufferUsageUniformBufferBit = 4,
        BufferUsageStorageBufferBit = 5,
        BufferUsageIndexBufferBit = 6,
        BufferUsageVertexBufferBit = 7,
        BufferUsageIndirectBufferBit = 8
    }
}