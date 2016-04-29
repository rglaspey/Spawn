using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct CopyDescriptorSet
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorSet srcSet;
        public uint srcBinding;
        public uint srcArrayElement;
        public DescriptorSet dstSet;
        public uint dstBinding;
        public uint dstArrayElement;
        public uint descriptorCount;
    }
}