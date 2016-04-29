using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineDynamicStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint dynamicStateCount;
        public DynamicState pDynamicStates;
    }
}