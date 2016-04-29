using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DisplayPresentInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public Rect2D srcRect;
        public Rect2D dstRect;
        public uint persistent;
    }
}