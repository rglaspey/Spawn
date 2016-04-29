using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SamplerCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public Filter magFilter;
        public Filter minFilter;
        public SamplerMipmapMode mipmapMode;
        public SamplerAddressMode addressModeU;
        public SamplerAddressMode addressModeV;
        public SamplerAddressMode addressModeW;
        public float mipLodBias;
        public uint anisotropyEnable;
        public float maxAnisotropy;
        public uint compareEnable;
        public CompareOp compareOp;
        public float minLod;
        public float maxLod;
        public BorderColor borderColor;
        public uint unnormalizedCoordinates;
    }
}