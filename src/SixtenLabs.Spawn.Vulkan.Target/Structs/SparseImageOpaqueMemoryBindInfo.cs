using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseImageOpaqueMemoryBindInfo
    {
        public Image image;
        public uint bindCount;
        public SparseMemoryBind pBinds;
    }
}