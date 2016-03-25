using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageUsage : int
    {
        ImageUsageTransferSrcBit = 1 << 0,
        ImageUsageTransferDstBit = 1 << 1,
        ImageUsageSampledBit = 1 << 2,
        ImageUsageStorageBit = 1 << 3,
        ImageUsageColorAttachmentBit = 1 << 4,
        ImageUsageDepthStencilAttachmentBit = 1 << 5,
        ImageUsageTransientAttachmentBit = 1 << 6,
        ImageUsageInputAttachmentBit = 1 << 7
    }
}