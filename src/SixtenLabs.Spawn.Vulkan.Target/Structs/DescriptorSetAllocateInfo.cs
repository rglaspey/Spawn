using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorSetAllocateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorPool descriptorPool;
        public uint descriptorSetCount;
        public DescriptorSetLayout pSetLayouts;
    }
}