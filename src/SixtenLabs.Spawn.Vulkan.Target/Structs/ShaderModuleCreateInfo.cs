using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ShaderModuleCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public UIntPtr codeSize;
        public uint pCode;
    }
}