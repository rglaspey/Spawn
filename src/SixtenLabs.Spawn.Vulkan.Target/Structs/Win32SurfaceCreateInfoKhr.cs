using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct Win32SurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public IntPtr hinstance;
        public IntPtr hwnd;
    }
}