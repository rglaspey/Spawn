using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum PipelineCreate : int
    {
        PipelineCreateDisableOptimizationBit = 1 << 0,
        PipelineCreateAllowDerivativesBit = 1 << 1,
        PipelineCreateDerivativeBit = 1 << 2
    }
}