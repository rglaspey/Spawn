using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PushConstantRange
    {
        public ShaderStageFlags stageFlags;
        public uint offset;
        public uint size;
    }
}