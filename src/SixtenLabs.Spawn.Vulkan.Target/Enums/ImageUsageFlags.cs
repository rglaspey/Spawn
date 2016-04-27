using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageUsageFlags
    {
        ImageUsageTransferSrcBit = 0,
        ImageUsageTransferDstBit = 1,
        ImageUsageSampledBit = 2,
        ImageUsageStorageBit = 3,
        ImageUsageColorAttachmentBit = 4,
        ImageUsageDepthStencilAttachmentBit = 5,
        ImageUsageTransientAttachmentBit = 6,
        ImageUsageInputAttachmentBit = 7
    }
}