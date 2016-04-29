using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DisplayPlaneCapabilitiesKhr
    {
        public DisplayPlaneAlphaFlagsKhr supportedAlpha;
        public Offset2D minSrcPosition;
        public Offset2D maxSrcPosition;
        public Extent2D minSrcExtent;
        public Extent2D maxSrcExtent;
        public Offset2D minDstPosition;
        public Offset2D maxDstPosition;
        public Extent2D minDstExtent;
        public Extent2D maxDstExtent;
    }
}