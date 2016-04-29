using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct FramebufferCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public RenderPass renderPass;
        public uint attachmentCount;
        public ImageView pAttachments;
        public uint width;
        public uint height;
        public uint layers;
    }
}