using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SubpassDescription
    {
        public uint flags;
        public PipelineBindPoint pipelineBindPoint;
        public uint inputAttachmentCount;
        public AttachmentReference pInputAttachments;
        public uint colorAttachmentCount;
        public AttachmentReference pColorAttachments;
        public AttachmentReference pResolveAttachments;
        public AttachmentReference pDepthStencilAttachment;
        public uint preserveAttachmentCount;
        public uint pPreserveAttachments;
    }
}