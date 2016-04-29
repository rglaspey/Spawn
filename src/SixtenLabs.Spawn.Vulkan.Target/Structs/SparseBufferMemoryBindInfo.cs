using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseBufferMemoryBindInfo
    {
        public Buffer buffer;
        public uint bindCount;
        public SparseMemoryBind pBinds;
    }
}