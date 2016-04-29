using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorBufferInfo
    {
        public Buffer buffer;
        public ulong offset;
        public ulong range;
    }
}