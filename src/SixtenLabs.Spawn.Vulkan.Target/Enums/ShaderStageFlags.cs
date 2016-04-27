using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ShaderStageFlags
    {
        ShaderStageVertexBit = 0,
        ShaderStageTessellationControlBit = 1,
        ShaderStageTessellationEvaluationBit = 2,
        ShaderStageGeometryBit = 3,
        ShaderStageFragmentBit = 4,
        ShaderStageComputeBit = 5,
        ShaderStageAllGraphics = 0x0000001F,
        ShaderStageAll = 0x7FFFFFFF
    }
}