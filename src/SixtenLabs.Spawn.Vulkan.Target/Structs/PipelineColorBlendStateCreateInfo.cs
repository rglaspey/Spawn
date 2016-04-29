using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineColorBlendStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint logicOpEnable;
        public LogicOp logicOp;
        public uint attachmentCount;
        public PipelineColorBlendAttachmentState pAttachments;
        public float blendConstants;
    }
}