using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct BufferCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public BufferCreateFlags flags;
        public ulong size;
        public BufferUsageFlags usage;
        public SharingMode sharingMode;
        public uint queueFamilyIndexCount;
        public uint pQueueFamilyIndices;
    }
}