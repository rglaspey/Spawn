using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageCreateFlags
    {
        ImageCreateSparseBindingBit = 0,
        ImageCreateSparseResidencyBit = 1,
        ImageCreateSparseAliasedBit = 2,
        ImageCreateMutableFormatBit = 3,
        ImageCreateCubeCompatibleBit = 4
    }
}