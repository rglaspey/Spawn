using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageUsageFlags
    {
        /// <summary>
                /// Can be used as a source of transfer operations
                /// </summary>
        ImageUsageTransferSrcBit = 0,
        /// <summary>
                /// Can be used as a destination of transfer operations
                /// </summary>
        ImageUsageTransferDstBit = 1,
        /// <summary>
                /// Can be sampled from (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
                /// </summary>
        ImageUsageSampledBit = 2,
        /// <summary>
                /// Can be used as storage image (STORAGE_IMAGE descriptor type)
                /// </summary>
        ImageUsageStorageBit = 3,
        /// <summary>
                /// Can be used as framebuffer color attachment
                /// </summary>
        ImageUsageColorAttachmentBit = 4,
        /// <summary>
                /// Can be used as framebuffer depth/stencil attachment
                /// </summary>
        ImageUsageDepthStencilAttachmentBit = 5,
        /// <summary>
                /// Image data not needed outside of rendering
                /// </summary>
        ImageUsageTransientAttachmentBit = 6,
        /// <summary>
                /// Can be used as framebuffer input attachment
                /// </summary>
        ImageUsageInputAttachmentBit = 7
    }
}