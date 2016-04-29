using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct BufferMemoryBarrier
    {
        public StructureType sType;
        public IntPtr pNext;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public Buffer buffer;
        public ulong offset;
        public ulong size;
    }
}