using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineVertexInputStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint vertexBindingDescriptionCount;
        public VertexInputBindingDescription pVertexBindingDescriptions;
        public uint vertexAttributeDescriptionCount;
        public VertexInputAttributeDescription pVertexAttributeDescriptions;
    }
}