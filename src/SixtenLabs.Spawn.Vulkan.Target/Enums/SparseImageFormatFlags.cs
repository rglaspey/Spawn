using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SparseImageFormatFlags
    {
        /// <summary>
                /// Image uses a single miptail region for all array layers
                /// </summary>
        SparseImageFormatSingleMiptailBit = 0,
        /// <summary>
                /// Image requires mip level dimensions to be an integer multiple of the sparse image block dimensions for non-miptail levels.
                /// </summary>
        SparseImageFormatAlignedMipSizeBit = 1,
        /// <summary>
                /// Image uses a non-standard sparse image block dimensions
                /// </summary>
        SparseImageFormatNonstandardBlockSizeBit = 2
    }
}