using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DisplayPropertiesKhr
    {
        public DisplayKhr display;
        public char displayName;
        public Extent2D physicalDimensions;
        public Extent2D physicalResolution;
        public SurfaceTransformFlagsKhr supportedTransforms;
        public uint planeReorderPossible;
        public uint persistentContent;
    }
}