using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseMemoryBind
    {
        public ulong resourceOffset;
        public ulong size;
        public DeviceMemory memory;
        public ulong memoryOffset;
        public SparseMemoryBindFlags flags;
    }
}