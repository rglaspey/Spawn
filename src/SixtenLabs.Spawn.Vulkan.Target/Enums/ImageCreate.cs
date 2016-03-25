using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageCreate : int
    {
        ImageCreateSparseBindingBit = 1 << 0,
        ImageCreateSparseResidencyBit = 1 << 1,
        ImageCreateSparseAliasedBit = 1 << 2,
        ImageCreateMutableFormatBit = 1 << 3,
        ImageCreateCubeCompatibleBit = 1 << 4
    }
}