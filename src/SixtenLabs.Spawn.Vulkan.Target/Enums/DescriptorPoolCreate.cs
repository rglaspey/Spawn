using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DescriptorPoolCreate : int
    {
        DescriptorPoolCreateFreeDescriptorSetBit = 1 << 0
    }
}