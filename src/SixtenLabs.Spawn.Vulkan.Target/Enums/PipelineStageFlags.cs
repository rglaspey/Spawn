using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum PipelineStageFlags
    {
        PipelineStageTopOfPipeBit = 0,
        PipelineStageDrawIndirectBit = 1,
        PipelineStageVertexInputBit = 2,
        PipelineStageVertexShaderBit = 3,
        PipelineStageTessellationControlShaderBit = 4,
        PipelineStageTessellationEvaluationShaderBit = 5,
        PipelineStageGeometryShaderBit = 6,
        PipelineStageFragmentShaderBit = 7,
        PipelineStageEarlyFragmentTestsBit = 8,
        PipelineStageLateFragmentTestsBit = 9,
        PipelineStageColorAttachmentOutputBit = 10,
        PipelineStageComputeShaderBit = 11,
        PipelineStageTransferBit = 12,
        PipelineStageBottomOfPipeBit = 13,
        PipelineStageHostBit = 14,
        PipelineStageAllGraphicsBit = 15,
        PipelineStageAllCommandsBit = 16
    }
}