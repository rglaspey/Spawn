using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum PipelineStageFlags
    {
        /// <summary>
                /// Before subsequent commands are processed
                /// </summary>
        PipelineStageTopOfPipeBit = 0,
        /// <summary>
                /// Draw/DispatchIndirect command fetch
                /// </summary>
        PipelineStageDrawIndirectBit = 1,
        /// <summary>
                /// Vertex/index fetch
                /// </summary>
        PipelineStageVertexInputBit = 2,
        /// <summary>
                /// Vertex shading
                /// </summary>
        PipelineStageVertexShaderBit = 3,
        /// <summary>
                /// Tessellation control shading
                /// </summary>
        PipelineStageTessellationControlShaderBit = 4,
        /// <summary>
                /// Tessellation evaluation shading
                /// </summary>
        PipelineStageTessellationEvaluationShaderBit = 5,
        /// <summary>
                /// Geometry shading
                /// </summary>
        PipelineStageGeometryShaderBit = 6,
        /// <summary>
                /// Fragment shading
                /// </summary>
        PipelineStageFragmentShaderBit = 7,
        /// <summary>
                /// Early fragment (depth and stencil) tests
                /// </summary>
        PipelineStageEarlyFragmentTestsBit = 8,
        /// <summary>
                /// Late fragment (depth and stencil) tests
                /// </summary>
        PipelineStageLateFragmentTestsBit = 9,
        /// <summary>
                /// Color attachment writes
                /// </summary>
        PipelineStageColorAttachmentOutputBit = 10,
        /// <summary>
                /// Compute shading
                /// </summary>
        PipelineStageComputeShaderBit = 11,
        /// <summary>
                /// Transfer/copy operations
                /// </summary>
        PipelineStageTransferBit = 12,
        /// <summary>
                /// After previous commands have completed
                /// </summary>
        PipelineStageBottomOfPipeBit = 13,
        /// <summary>
                /// Indicates host (CPU) is a source/sink of the dependency
                /// </summary>
        PipelineStageHostBit = 14,
        /// <summary>
                /// All stages of the graphics pipeline
                /// </summary>
        PipelineStageAllGraphicsBit = 15,
        /// <summary>
                /// All stages supported on the queue
                /// </summary>
        PipelineStageAllCommandsBit = 16
    }
}