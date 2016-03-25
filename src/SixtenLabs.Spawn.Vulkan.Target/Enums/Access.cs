using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum Access : int
    {
        AccessIndirectCommandReadBit = 1 << 0,
        AccessIndexReadBit = 1 << 1,
        AccessVertexAttributeReadBit = 1 << 2,
        AccessUniformReadBit = 1 << 3,
        AccessInputAttachmentReadBit = 1 << 4,
        AccessShaderReadBit = 1 << 5,
        AccessShaderWriteBit = 1 << 6,
        AccessColorAttachmentReadBit = 1 << 7,
        AccessColorAttachmentWriteBit = 1 << 8,
        AccessDepthStencilAttachmentReadBit = 1 << 9,
        AccessDepthStencilAttachmentWriteBit = 1 << 10,
        AccessTransferReadBit = 1 << 11,
        AccessTransferWriteBit = 1 << 12,
        AccessHostReadBit = 1 << 13,
        AccessHostWriteBit = 1 << 14,
        AccessMemoryReadBit = 1 << 15,
        AccessMemoryWriteBit = 1 << 16
    }
}