using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct CommandBufferInheritanceInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public RenderPass renderPass;
        public uint subpass;
        public Framebuffer framebuffer;
        public uint occlusionQueryEnable;
        public QueryControlFlags queryFlags;
        public QueryPipelineStatisticFlags pipelineStatistics;
    }
}