using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SparseImageFormat : int
    {
        SparseImageFormatSingleMiptailBit = 1 << 0,
        SparseImageFormatAlignedMipSizeBit = 1 << 1,
        SparseImageFormatNonstandardBlockSizeBit = 1 << 2
    }
}