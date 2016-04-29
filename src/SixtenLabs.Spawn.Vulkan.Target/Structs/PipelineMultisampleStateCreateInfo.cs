using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineMultisampleStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public SampleCountFlags rasterizationSamples;
        public uint sampleShadingEnable;
        public float minSampleShading;
        public uint pSampleMask;
        public uint alphaToCoverageEnable;
        public uint alphaToOneEnable;
    }
}