using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorSetLayoutBinding
    {
        public uint binding;
        public DescriptorType descriptorType;
        public uint descriptorCount;
        public ShaderStageFlags stageFlags;
        public Sampler pImmutableSamplers;
    }
}