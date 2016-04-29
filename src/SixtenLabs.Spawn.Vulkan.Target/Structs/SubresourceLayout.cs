using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SubresourceLayout
    {
        public ulong offset;
        public ulong size;
        public ulong rowPitch;
        public ulong arrayPitch;
        public ulong depthPitch;
    }
}