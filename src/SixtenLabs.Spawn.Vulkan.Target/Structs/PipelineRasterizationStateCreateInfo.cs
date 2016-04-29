using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineRasterizationStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint depthClampEnable;
        public uint rasterizerDiscardEnable;
        public PolygonMode polygonMode;
        public CullModeFlags cullMode;
        public FrontFace frontFace;
        public uint depthBiasEnable;
        public float depthBiasConstantFactor;
        public float depthBiasClamp;
        public float depthBiasSlopeFactor;
        public float lineWidth;
    }
}