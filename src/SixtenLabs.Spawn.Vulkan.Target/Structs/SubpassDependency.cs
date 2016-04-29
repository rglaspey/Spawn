using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SubpassDependency
    {
        public uint srcSubpass;
        public uint dstSubpass;
        public PipelineStageFlags srcStageMask;
        public PipelineStageFlags dstStageMask;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public DependencyFlags dependencyFlags;
    }
}