using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct XlibSurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public IntPtr dpy;
        public IntPtr window;
    }
}