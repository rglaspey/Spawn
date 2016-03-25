using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ShaderStage : int
    {
        ShaderStageVertexBit = 1 << 0,
        ShaderStageTessellationControlBit = 1 << 1,
        ShaderStageTessellationEvaluationBit = 1 << 2,
        ShaderStageGeometryBit = 1 << 3,
        ShaderStageFragmentBit = 1 << 4,
        ShaderStageComputeBit = 1 << 5,
        ShaderStageAllGraphics = 1 << 0x0000001F,
        ShaderStageAll = 1 << 0x7FFFFFFF
    }
}