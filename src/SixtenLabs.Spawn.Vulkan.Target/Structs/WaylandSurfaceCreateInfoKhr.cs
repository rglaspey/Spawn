using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct WaylandSurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public IntPtr display;
        public IntPtr surface;
    }
}