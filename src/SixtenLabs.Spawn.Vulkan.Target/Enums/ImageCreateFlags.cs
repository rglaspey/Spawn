using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ImageCreateFlags
    {
        /// <summary>
                /// Image should support sparse backing
                /// </summary>
        ImageCreateSparseBindingBit = 0,
        /// <summary>
                /// Image should support sparse backing with partial residency
                /// </summary>
        ImageCreateSparseResidencyBit = 1,
        /// <summary>
                /// Image should support constent data access to physical memory ranges mapped into multiple locations of sparse images
                /// </summary>
        ImageCreateSparseAliasedBit = 2,
        /// <summary>
                /// Allows image views to have different format than the base image
                /// </summary>
        ImageCreateMutableFormatBit = 3,
        /// <summary>
                /// Allows creating image views with cube type from the created image
                /// </summary>
        ImageCreateCubeCompatibleBit = 4
    }
}