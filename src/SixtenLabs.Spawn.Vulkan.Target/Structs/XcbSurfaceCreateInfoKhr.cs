using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct XcbSurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public IntPtr connection;
        public IntPtr window;
    }
}