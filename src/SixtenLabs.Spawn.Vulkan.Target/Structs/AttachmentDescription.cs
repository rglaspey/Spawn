using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct AttachmentDescription
    {
        public AttachmentDescriptionFlags flags;
        public Format format;
        public SampleCountFlags samples;
        public AttachmentLoadOp loadOp;
        public AttachmentStoreOp storeOp;
        public AttachmentLoadOp stencilLoadOp;
        public AttachmentStoreOp stencilStoreOp;
        public ImageLayout initialLayout;
        public ImageLayout finalLayout;
    }
}