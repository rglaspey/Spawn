using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public static class ApiConstants
    {
        public const uint MaxPhysicalDeviceNameSize = 256;
        public const uint UuidSize = 16;
        public const uint MaxExtensionNameSize = 256;
        public const uint MaxDescriptionSize = 256;
        public const uint MaxMemoryTypes = 32;
        public const uint MaxMemoryHeaps = 16;
        public const float LodClampNone = 1000F;
        public const uint RemainingMipLevels = uint.MaxValue;
        public const uint RemainingArrayLayers = uint.MaxValue;
        public const ulong WholeSize = ulong.MaxValue;
        public const uint AttachmentUnused = uint.MaxValue;
        public const uint TRUE = 1;
        public const uint FALSE = 0;
        public const uint QueueFamilyIgnored = uint.MaxValue;
        public const uint SubpassExternal = uint.MaxValue;
    }
}