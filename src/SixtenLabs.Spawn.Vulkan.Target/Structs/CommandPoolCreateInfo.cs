using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct CommandPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public CommandPoolCreateFlags flags;
        public uint queueFamilyIndex;
    }
}