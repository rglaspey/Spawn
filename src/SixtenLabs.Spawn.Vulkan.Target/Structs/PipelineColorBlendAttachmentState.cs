using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineColorBlendAttachmentState
    {
        public uint blendEnable;
        public BlendFactor srcColorBlendFactor;
        public BlendFactor dstColorBlendFactor;
        public BlendOp colorBlendOp;
        public BlendFactor srcAlphaBlendFactor;
        public BlendFactor dstAlphaBlendFactor;
        public BlendOp alphaBlendOp;
        public ColorComponentFlags colorWriteMask;
    }
}