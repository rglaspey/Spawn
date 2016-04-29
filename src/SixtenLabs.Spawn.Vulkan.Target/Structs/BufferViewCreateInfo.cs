using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct BufferViewCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public Buffer buffer;
        public Format format;
        public ulong offset;
        public ulong range;
    }
}