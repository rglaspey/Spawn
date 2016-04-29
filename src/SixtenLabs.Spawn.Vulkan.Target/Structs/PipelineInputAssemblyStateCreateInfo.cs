using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineInputAssemblyStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public PrimitiveTopology topology;
        public uint primitiveRestartEnable;
    }
}