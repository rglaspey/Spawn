namespace SixtenLabs.Spawn.Vulkan.Target
{
    public enum DescriptorType : int
    {
        DescriptorTypeSampler = 0,
        DescriptorTypeCombinedImageSampler = 1,
        DescriptorTypeSampledImage = 2,
        DescriptorTypeStorageImage = 3,
        DescriptorTypeUniformTexelBuffer = 4,
        DescriptorTypeStorageTexelBuffer = 5,
        DescriptorTypeUniformBuffer = 6,
        DescriptorTypeStorageBuffer = 7,
        DescriptorTypeUniformBufferDynamic = 8,
        DescriptorTypeStorageBufferDynamic = 9,
        DescriptorTypeInputAttachment = 10
    }
}