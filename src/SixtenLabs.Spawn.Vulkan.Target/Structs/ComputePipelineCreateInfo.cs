using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ComputePipelineCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineCreateFlags flags;
        public PipelineShaderStageCreateInfo stage;
        public PipelineLayout layout;
        public Pipeline basePipelineHandle;
        public int basePipelineIndex;
    }
}