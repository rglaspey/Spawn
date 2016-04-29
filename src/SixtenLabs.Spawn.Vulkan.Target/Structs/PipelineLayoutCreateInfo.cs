using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineLayoutCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint setLayoutCount;
        public DescriptorSetLayout pSetLayouts;
        public uint pushConstantRangeCount;
        public PushConstantRange pPushConstantRanges;
    }
}