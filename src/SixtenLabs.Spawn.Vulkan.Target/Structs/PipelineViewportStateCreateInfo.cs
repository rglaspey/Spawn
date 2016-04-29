using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineViewportStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint viewportCount;
        public Viewport pViewports;
        public uint scissorCount;
        public Rect2D pScissors;
    }
}