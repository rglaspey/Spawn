using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryPipelineStatistic : int
    {
        QueryPipelineStatisticInputAssemblyVerticesBit = 1 << 0,
        QueryPipelineStatisticInputAssemblyPrimitivesBit = 1 << 1,
        QueryPipelineStatisticVertexShaderInvocationsBit = 1 << 2,
        QueryPipelineStatisticGeometryShaderInvocationsBit = 1 << 3,
        QueryPipelineStatisticGeometryShaderPrimitivesBit = 1 << 4,
        QueryPipelineStatisticClippingInvocationsBit = 1 << 5,
        QueryPipelineStatisticClippingPrimitivesBit = 1 << 6,
        QueryPipelineStatisticFragmentShaderInvocationsBit = 1 << 7,
        QueryPipelineStatisticTessellationControlShaderPatchesBit = 1 << 8,
        QueryPipelineStatisticTessellationEvaluationShaderInvocationsBit = 1 << 9,
        QueryPipelineStatisticComputeShaderInvocationsBit = 1 << 10
    }
}