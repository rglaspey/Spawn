using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum Dependency : int
    {
        DependencyByRegionBit = 1 << 0
    }
}