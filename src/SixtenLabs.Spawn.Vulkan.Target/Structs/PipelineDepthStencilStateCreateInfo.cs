using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineDepthStencilStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint depthTestEnable;
        public uint depthWriteEnable;
        public CompareOp depthCompareOp;
        public uint depthBoundsTestEnable;
        public uint stencilTestEnable;
        public StencilOpState front;
        public StencilOpState back;
        public float minDepthBounds;
        public float maxDepthBounds;
    }
}