using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorPoolCreateFlags flags;
        public uint maxSets;
        public uint poolSizeCount;
        public DescriptorPoolSize pPoolSizes;
    }
}