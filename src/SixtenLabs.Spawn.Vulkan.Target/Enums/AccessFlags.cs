using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum AccessFlags
    {
        AccessIndirectCommandReadBit = 0,
        AccessIndexReadBit = 1,
        AccessVertexAttributeReadBit = 2,
        AccessUniformReadBit = 3,
        AccessInputAttachmentReadBit = 4,
        AccessShaderReadBit = 5,
        AccessShaderWriteBit = 6,
        AccessColorAttachmentReadBit = 7,
        AccessColorAttachmentWriteBit = 8,
        AccessDepthStencilAttachmentReadBit = 9,
        AccessDepthStencilAttachmentWriteBit = 10,
        AccessTransferReadBit = 11,
        AccessTransferWriteBit = 12,
        AccessHostReadBit = 13,
        AccessHostWriteBit = 14,
        AccessMemoryReadBit = 15,
        AccessMemoryWriteBit = 16
    }
}