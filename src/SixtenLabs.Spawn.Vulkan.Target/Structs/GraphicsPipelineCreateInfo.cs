using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct GraphicsPipelineCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineCreateFlags flags;
        public uint stageCount;
        public PipelineShaderStageCreateInfo pStages;
        public PipelineVertexInputStateCreateInfo pVertexInputState;
        public PipelineInputAssemblyStateCreateInfo pInputAssemblyState;
        public PipelineTessellationStateCreateInfo pTessellationState;
        public PipelineViewportStateCreateInfo pViewportState;
        public PipelineRasterizationStateCreateInfo pRasterizationState;
        public PipelineMultisampleStateCreateInfo pMultisampleState;
        public PipelineDepthStencilStateCreateInfo pDepthStencilState;
        public PipelineColorBlendStateCreateInfo pColorBlendState;
        public PipelineDynamicStateCreateInfo pDynamicState;
        public PipelineLayout layout;
        public RenderPass renderPass;
        public uint subpass;
        public Pipeline basePipelineHandle;
        public int basePipelineIndex;
    }
}