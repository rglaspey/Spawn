using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum DependencyFlags
    {
        /// <summary>
                /// Dependency is per pixel region 
                /// </summary>
        DependencyByRegionBit = 0
    }
}