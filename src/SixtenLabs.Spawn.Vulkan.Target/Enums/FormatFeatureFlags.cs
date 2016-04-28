using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum FormatFeatureFlags
    {
        /// <summary>
                /// Format can be used for sampled images (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
                /// </summary>
        FormatFeatureSampledImageBit = 0,
        /// <summary>
                /// Format can be used for storage images (STORAGE_IMAGE descriptor type)
                /// </summary>
        FormatFeatureStorageImageBit = 1,
        /// <summary>
                /// Format supports atomic operations in case it's used for storage images
                /// </summary>
        FormatFeatureStorageImageAtomicBit = 2,
        /// <summary>
                /// Format can be used for uniform texel buffers (TBOs)
                /// </summary>
        FormatFeatureUniformTexelBufferBit = 3,
        /// <summary>
                /// Format can be used for storage texel buffers (IBOs)
                /// </summary>
        FormatFeatureStorageTexelBufferBit = 4,
        /// <summary>
                /// Format supports atomic operations in case it's used for storage texel buffers
                /// </summary>
        FormatFeatureStorageTexelBufferAtomicBit = 5,
        /// <summary>
                /// Format can be used for vertex buffers (VBOs)
                /// </summary>
        FormatFeatureVertexBufferBit = 6,
        /// <summary>
                /// Format can be used for color attachment images
                /// </summary>
        FormatFeatureColorAttachmentBit = 7,
        /// <summary>
                /// Format supports blending in case it's used for color attachment images
                /// </summary>
        FormatFeatureColorAttachmentBlendBit = 8,
        /// <summary>
                /// Format can be used for depth/stencil attachment images
                /// </summary>
        FormatFeatureDepthStencilAttachmentBit = 9,
        /// <summary>
                /// Format can be used as the source image of blits with vkCmdBlitImage
                /// </summary>
        FormatFeatureBlitSrcBit = 10,
        /// <summary>
                /// Format can be used as the destination image of blits with vkCmdBlitImage
                /// </summary>
        FormatFeatureBlitDstBit = 11,
        /// <summary>
                /// Format can be filtered with VK_FILTER_LINEAR when being sampled
                /// </summary>
        FormatFeatureSampledImageFilterLinearBit = 12
    }
}