using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorSetLayoutCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint bindingCount;
        public DescriptorSetLayoutBinding pBindings;
    }
}