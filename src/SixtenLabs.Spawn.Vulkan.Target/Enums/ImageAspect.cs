using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageAspect : int
    {
        ImageAspectColorBit = 1 << 0,
        ImageAspectDepthBit = 1 << 1,
        ImageAspectStencilBit = 1 << 2,
        ImageAspectMetadataBit = 1 << 3
    }
}