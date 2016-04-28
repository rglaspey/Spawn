using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DescriptorPoolCreateFlags
    {
        /// <summary>
                /// Descriptor sets may be freed individually
                /// </summary>
        DescriptorPoolCreateFreeDescriptorSetBit = 0
    }
}