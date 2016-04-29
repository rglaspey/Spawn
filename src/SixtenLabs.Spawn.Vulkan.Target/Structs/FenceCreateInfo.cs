using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct FenceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public FenceCreateFlags flags;
    }
}