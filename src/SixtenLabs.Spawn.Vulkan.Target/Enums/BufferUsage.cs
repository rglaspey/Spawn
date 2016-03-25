using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferUsage : int
    {
        BufferUsageTransferSrcBit = 1 << 0,
        BufferUsageTransferDstBit = 1 << 1,
        BufferUsageUniformTexelBufferBit = 1 << 2,
        BufferUsageStorageTexelBufferBit = 1 << 3,
        BufferUsageUniformBufferBit = 1 << 4,
        BufferUsageStorageBufferBit = 1 << 5,
        BufferUsageIndexBufferBit = 1 << 6,
        BufferUsageVertexBufferBit = 1 << 7,
        BufferUsageIndirectBufferBit = 1 << 8
    }
}