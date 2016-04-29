using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct MappedMemoryRange
    {
        public StructureType sType;
        public IntPtr pNext;
        public DeviceMemory memory;
        public ulong offset;
        public ulong size;
    }
}