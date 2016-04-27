using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SparseImageFormatFlags
    {
        SparseImageFormatSingleMiptailBit = 0,
        SparseImageFormatAlignedMipSizeBit = 1,
        SparseImageFormatNonstandardBlockSizeBit = 2
    }
}