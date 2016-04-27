using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryPipelineStatisticFlags
    {
        QueryPipelineStatisticInputAssemblyVerticesBit = 0,
        QueryPipelineStatisticInputAssemblyPrimitivesBit = 1,
        QueryPipelineStatisticVertexShaderInvocationsBit = 2,
        QueryPipelineStatisticGeometryShaderInvocationsBit = 3,
        QueryPipelineStatisticGeometryShaderPrimitivesBit = 4,
        QueryPipelineStatisticClippingInvocationsBit = 5,
        QueryPipelineStatisticClippingPrimitivesBit = 6,
        QueryPipelineStatisticFragmentShaderInvocationsBit = 7,
        QueryPipelineStatisticTessellationControlShaderPatchesBit = 8,
        QueryPipelineStatisticTessellationEvaluationShaderInvocationsBit = 9,
        QueryPipelineStatisticComputeShaderInvocationsBit = 10
    }
}