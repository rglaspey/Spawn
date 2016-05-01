using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineRasterizationStateRasterizationOrderAMD
    {
        public StructureType sType;
        public IntPtr pNext;
        public RasterizationOrderAMD rasterizationOrder;
    }
}