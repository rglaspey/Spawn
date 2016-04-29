using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct StencilOpState
    {
        public StencilOp failOp;
        public StencilOp passOp;
        public StencilOp depthFailOp;
        public CompareOp compareOp;
        public uint compareMask;
        public uint writeMask;
        public uint reference;
    }
}