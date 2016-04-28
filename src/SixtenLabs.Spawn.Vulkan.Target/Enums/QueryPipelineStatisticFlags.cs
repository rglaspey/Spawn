using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum QueryPipelineStatisticFlags
    {
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticInputAssemblyVerticesBit = 0,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticInputAssemblyPrimitivesBit = 1,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticVertexShaderInvocationsBit = 2,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticGeometryShaderInvocationsBit = 3,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticGeometryShaderPrimitivesBit = 4,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticClippingInvocationsBit = 5,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticClippingPrimitivesBit = 6,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticFragmentShaderInvocationsBit = 7,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticTessellationControlShaderPatchesBit = 8,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticTessellationEvaluationShaderInvocationsBit = 9,
        /// <summary>
                /// Optional
                /// </summary>
        QueryPipelineStatisticComputeShaderInvocationsBit = 10
    }
}