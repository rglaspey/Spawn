using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct VertexInputAttributeDescription
    {
        public uint location;
        public uint binding;
        public Format format;
        public uint offset;
    }
}