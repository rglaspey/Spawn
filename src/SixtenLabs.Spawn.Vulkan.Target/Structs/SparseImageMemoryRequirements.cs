using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseImageMemoryRequirements
    {
        public SparseImageFormatProperties formatProperties;
        public uint imageMipTailFirstLod;
        public ulong imageMipTailSize;
        public ulong imageMipTailOffset;
        public ulong imageMipTailStride;
    }
}