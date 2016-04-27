using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum PipelineCreateFlags
    {
        PipelineCreateDisableOptimizationBit = 0,
        PipelineCreateAllowDerivativesBit = 1,
        PipelineCreateDerivativeBit = 2
    }
}