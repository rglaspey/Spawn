using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DrawIndirectCommand
    {
        public uint vertexCount;
        public uint instanceCount;
        public uint firstVertex;
        public uint firstInstance;
    }
}