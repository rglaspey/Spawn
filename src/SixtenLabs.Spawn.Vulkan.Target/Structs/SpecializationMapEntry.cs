using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SpecializationMapEntry
    {
        public uint constantID;
        public uint offset;
        public UIntPtr size;
    }
}