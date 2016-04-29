using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DisplaySurfaceCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public DisplayModeKhr displayMode;
        public uint planeIndex;
        public uint planeStackIndex;
        public SurfaceTransformFlagsKhr transform;
        public float globalAlpha;
        public DisplayPlaneAlphaFlagsKhr alphaMode;
        public Extent2D imageExtent;
    }
}