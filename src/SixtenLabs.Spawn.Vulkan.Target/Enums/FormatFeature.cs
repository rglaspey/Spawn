using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum FormatFeature : int
    {
        FormatFeatureSampledImageBit = 1 << 0,
        FormatFeatureStorageImageBit = 1 << 1,
        FormatFeatureStorageImageAtomicBit = 1 << 2,
        FormatFeatureUniformTexelBufferBit = 1 << 3,
        FormatFeatureStorageTexelBufferBit = 1 << 4,
        FormatFeatureStorageTexelBufferAtomicBit = 1 << 5,
        FormatFeatureVertexBufferBit = 1 << 6,
        FormatFeatureColorAttachmentBit = 1 << 7,
        FormatFeatureColorAttachmentBlendBit = 1 << 8,
        FormatFeatureDepthStencilAttachmentBit = 1 << 9,
        FormatFeatureBlitSrcBit = 1 << 10,
        FormatFeatureBlitDstBit = 1 << 11,
        FormatFeatureSampledImageFilterLinearBit = 1 << 12
    }
}