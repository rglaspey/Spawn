using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum FormatFeatureFlags
    {
        FormatFeatureSampledImageBit = 0,
        FormatFeatureStorageImageBit = 1,
        FormatFeatureStorageImageAtomicBit = 2,
        FormatFeatureUniformTexelBufferBit = 3,
        FormatFeatureStorageTexelBufferBit = 4,
        FormatFeatureStorageTexelBufferAtomicBit = 5,
        FormatFeatureVertexBufferBit = 6,
        FormatFeatureColorAttachmentBit = 7,
        FormatFeatureColorAttachmentBlendBit = 8,
        FormatFeatureDepthStencilAttachmentBit = 9,
        FormatFeatureBlitSrcBit = 10,
        FormatFeatureBlitDstBit = 11,
        FormatFeatureSampledImageFilterLinearBit = 12
    }
}