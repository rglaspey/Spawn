using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct WriteDescriptorSet
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorSet dstSet;
        public uint dstBinding;
        public uint dstArrayElement;
        public uint descriptorCount;
        public DescriptorType descriptorType;
        public DescriptorImageInfo pImageInfo;
        public DescriptorBufferInfo pBufferInfo;
        public BufferView pTexelBufferView;
    }
}