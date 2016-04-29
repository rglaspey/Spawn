using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct CommandBufferBeginInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public CommandBufferUsageFlags flags;
        public CommandBufferInheritanceInfo pInheritanceInfo;
    }
}