using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct FormatProperties
    {
        public FormatFeatureFlags linearTilingFeatures;
        public FormatFeatureFlags optimalTilingFeatures;
        public FormatFeatureFlags bufferFeatures;
    }
}