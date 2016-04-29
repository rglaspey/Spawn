using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PipelineTessellationStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint patchControlPoints;
    }
}