using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum BufferUsageFlags
    {
        /// <summary>
                /// Can be used as a source of transfer operations
                /// </summary>
        BufferUsageTransferSrcBit = 0,
        /// <summary>
                /// Can be used as a destination of transfer operations
                /// </summary>
        BufferUsageTransferDstBit = 1,
        /// <summary>
                /// Can be used as TBO
                /// </summary>
        BufferUsageUniformTexelBufferBit = 2,
        /// <summary>
                /// Can be used as IBO
                /// </summary>
        BufferUsageStorageTexelBufferBit = 3,
        /// <summary>
                /// Can be used as UBO
                /// </summary>
        BufferUsageUniformBufferBit = 4,
        /// <summary>
                /// Can be used as SSBO
                /// </summary>
        BufferUsageStorageBufferBit = 5,
        /// <summary>
                /// Can be used as source of fixed-function index fetch (index buffer)
                /// </summary>
        BufferUsageIndexBufferBit = 6,
        /// <summary>
                /// Can be used as source of fixed-function vertex fetch (VBO)
                /// </summary>
        BufferUsageVertexBufferBit = 7,
        /// <summary>
                /// Can be the source of indirect parameters (e.g. indirect buffer, parameter buffer)
                /// </summary>
        BufferUsageIndirectBufferBit = 8
    }
}