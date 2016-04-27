using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageAspectFlags
    {
        ImageAspectColorBit = 0,
        ImageAspectDepthBit = 1,
        ImageAspectStencilBit = 2,
        ImageAspectMetadataBit = 3
    }
}