using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct RenderPassBeginInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public RenderPass renderPass;
        public Framebuffer framebuffer;
        public Rect2D renderArea;
        public uint clearValueCount;
        public ClearValue pClearValues;
    }
}