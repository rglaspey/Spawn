using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct RenderPassCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint attachmentCount;
        public AttachmentDescription pAttachments;
        public uint subpassCount;
        public SubpassDescription pSubpasses;
        public uint dependencyCount;
        public SubpassDependency pDependencies;
    }
}