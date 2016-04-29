using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SpecializationInfo
    {
        public uint mapEntryCount;
        public SpecializationMapEntry pMapEntries;
        public UIntPtr dataSize;
        public IntPtr pData;
    }
}