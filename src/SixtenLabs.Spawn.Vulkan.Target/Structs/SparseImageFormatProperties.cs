using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SparseImageFormatProperties
    {
        public ImageAspectFlags aspectMask;
        public Extent3D imageGranularity;
        public SparseImageFormatFlags flags;
    }
}