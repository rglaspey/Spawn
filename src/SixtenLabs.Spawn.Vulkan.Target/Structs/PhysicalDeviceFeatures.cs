using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PhysicalDeviceFeatures
    {
        public uint robustBufferAccess;
        public uint fullDrawIndexUint32;
        public uint imageCubeArray;
        public uint independentBlend;
        public uint geometryShader;
        public uint tessellationShader;
        public uint sampleRateShading;
        public uint dualSrcBlend;
        public uint logicOp;
        public uint multiDrawIndirect;
        public uint drawIndirectFirstInstance;
        public uint depthClamp;
        public uint depthBiasClamp;
        public uint fillModeNonSolid;
        public uint depthBounds;
        public uint wideLines;
        public uint largePoints;
        public uint alphaToOne;
        public uint multiViewport;
        public uint samplerAnisotropy;
        public uint textureCompressionETC2;
        public uint textureCompressionASTC_LDR;
        public uint textureCompressionBC;
        public uint occlusionQueryPrecise;
        public uint pipelineStatisticsQuery;
        public uint vertexPipelineStoresAndAtomics;
        public uint fragmentStoresAndAtomics;
        public uint shaderTessellationAndGeometryPointSize;
        public uint shaderImageGatherExtended;
        public uint shaderStorageImageExtendedFormats;
        public uint shaderStorageImageMultisample;
        public uint shaderStorageImageReadWithoutFormat;
        public uint shaderStorageImageWriteWithoutFormat;
        public uint shaderUniformBufferArrayDynamicIndexing;
        public uint shaderSampledImageArrayDynamicIndexing;
        public uint shaderStorageBufferArrayDynamicIndexing;
        public uint shaderStorageImageArrayDynamicIndexing;
        public uint shaderClipDistance;
        public uint shaderCullDistance;
        public uint shaderFloat64;
        public uint shaderInt64;
        public uint shaderInt16;
        public uint shaderResourceResidency;
        public uint shaderResourceMinLod;
        public uint sparseBinding;
        public uint sparseResidencyBuffer;
        public uint sparseResidencyImage2D;
        public uint sparseResidencyImage3D;
        public uint sparseResidency2Samples;
        public uint sparseResidency4Samples;
        public uint sparseResidency8Samples;
        public uint sparseResidency16Samples;
        public uint sparseResidencyAliased;
        public uint variableMultisampleRate;
        public uint inheritedQueries;
    }
}