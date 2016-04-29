using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SurfaceCapabilitiesKhr
    {
        public uint minImageCount;
        public uint maxImageCount;
        public Extent2D currentExtent;
        public Extent2D minImageExtent;
        public Extent2D maxImageExtent;
        public uint maxImageArrayLayers;
        public SurfaceTransformFlagsKhr supportedTransforms;
        public SurfaceTransformFlagsKhr currentTransform;
        public CompositeAlphaFlagsKhr supportedCompositeAlpha;
        public ImageUsageFlags supportedUsageFlags;
    }
}