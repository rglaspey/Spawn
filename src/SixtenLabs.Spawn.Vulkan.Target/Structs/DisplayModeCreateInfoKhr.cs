using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DisplayModeCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public DisplayModeParametersKhr parameters;
    }
}