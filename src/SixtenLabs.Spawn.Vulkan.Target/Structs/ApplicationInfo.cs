using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct ApplicationInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public char pApplicationName;
        public uint applicationVersion;
        public char pEngineName;
        public uint engineVersion;
        public uint apiVersion;
    }
}