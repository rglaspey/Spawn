using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct VertexInputBindingDescription
    {
        public uint binding;
        public uint stride;
        public VertexInputRate inputRate;
    }
}