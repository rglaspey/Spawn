using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineShaderStageCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public ShaderStageFlags stage;
        public ShaderModule module;
        public char pName;
        public SpecializationInfo pSpecializationInfo;
    }
}