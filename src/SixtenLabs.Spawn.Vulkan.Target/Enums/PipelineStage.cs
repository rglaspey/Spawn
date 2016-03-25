using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum PipelineStage : int
    {
        PipelineStageTopOfPipeBit = 1 << 0,
        PipelineStageDrawIndirectBit = 1 << 1,
        PipelineStageVertexInputBit = 1 << 2,
        PipelineStageVertexShaderBit = 1 << 3,
        PipelineStageTessellationControlShaderBit = 1 << 4,
        PipelineStageTessellationEvaluationShaderBit = 1 << 5,
        PipelineStageGeometryShaderBit = 1 << 6,
        PipelineStageFragmentShaderBit = 1 << 7,
        PipelineStageEarlyFragmentTestsBit = 1 << 8,
        PipelineStageLateFragmentTestsBit = 1 << 9,
        PipelineStageColorAttachmentOutputBit = 1 << 10,
        PipelineStageComputeShaderBit = 1 << 11,
        PipelineStageTransferBit = 1 << 12,
        PipelineStageBottomOfPipeBit = 1 << 13,
        PipelineStageHostBit = 1 << 14,
        PipelineStageAllGraphicsBit = 1 << 15,
        PipelineStageAllCommandsBit = 1 << 16
    }
}