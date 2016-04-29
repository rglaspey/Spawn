using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineCacheCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public UIntPtr initialDataSize;
        public IntPtr pInitialData;
    }
}