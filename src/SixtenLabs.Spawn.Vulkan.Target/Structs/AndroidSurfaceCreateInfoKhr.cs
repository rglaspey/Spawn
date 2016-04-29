using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct AndroidSurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public IntPtr window;
    }
}