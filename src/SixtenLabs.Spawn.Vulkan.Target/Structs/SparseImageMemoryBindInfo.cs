using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseImageMemoryBindInfo
    {
        public Image image;
        public uint bindCount;
        public SparseImageMemoryBind pBinds;
    }
}