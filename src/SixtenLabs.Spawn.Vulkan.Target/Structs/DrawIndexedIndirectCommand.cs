using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DrawIndexedIndirectCommand
    {
        public uint indexCount;
        public uint instanceCount;
        public uint firstIndex;
        public int vertexOffset;
        public uint firstInstance;
    }
}