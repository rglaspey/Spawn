using System;
using System.Runtime.InteropServices;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    internal static class NativeMethods
    {
        private const string VulkanLibrary = "vulkan-1.dll";
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateInstance(InstanceCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Instance* @pInstance);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyInstance(Instance @instance, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EnumeratePhysicalDevices(Instance @instance, uint* @pPhysicalDeviceCount, PhysicalDevice* @pPhysicalDevices);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetDeviceProcAddr(Device @device, char* @pName);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetInstanceProcAddr(Instance @instance, char* @pName);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceProperties(PhysicalDevice @physicalDevice, PhysicalDeviceProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice @physicalDevice, uint* @pQueueFamilyPropertyCount, QueueFamilyProperties* @pQueueFamilyProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceMemoryProperties(PhysicalDevice @physicalDevice, PhysicalDeviceMemoryProperties* @pMemoryProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceFeatures(PhysicalDevice @physicalDevice, PhysicalDeviceFeatures* @pFeatures);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceFormatProperties(PhysicalDevice @physicalDevice, Format @format, FormatProperties* @pFormatProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice @physicalDevice, Format @format, ImageType @type, ImageTiling @tiling, ImageUsageFlags @usage, ImageCreateFlags @flags, ImageFormatProperties* @pImageFormatProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDevice(PhysicalDevice @physicalDevice, DeviceCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Device* @pDevice);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyDevice(Device @device, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EnumerateInstanceLayerProperties(uint* @pPropertyCount, LayerProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EnumerateInstanceExtensionProperties(char* @pLayerName, uint* @pPropertyCount, ExtensionProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EnumerateDeviceLayerProperties(PhysicalDevice @physicalDevice, uint* @pPropertyCount, LayerProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EnumerateDeviceExtensionProperties(PhysicalDevice @physicalDevice, char* @pLayerName, uint* @pPropertyCount, ExtensionProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetDeviceQueue(Device @device, uint @queueFamilyIndex, uint @queueIndex, Queue* @pQueue);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result QueueSubmit(Queue @queue, uint @submitCount, SubmitInfo* @pSubmits, Fence @fence);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result QueueWaitIdle(Queue @queue);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result DeviceWaitIdle(Device @device);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result AllocateMemory(Device @device, MemoryAllocateInfo* @pAllocateInfo, AllocationCallbacks* @pAllocator, DeviceMemory* @pMemory);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr FreeMemory(Device @device, DeviceMemory @memory, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result MapMemory(Device @device, DeviceMemory @memory, ulong @offset, ulong @size, uint @flags, IntPtr @ppData);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr UnmapMemory(Device @device, DeviceMemory @memory);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result FlushMappedMemoryRanges(Device @device, uint @memoryRangeCount, MappedMemoryRange* @pMemoryRanges);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result InvalidateMappedMemoryRanges(Device @device, uint @memoryRangeCount, MappedMemoryRange* @pMemoryRanges);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetDeviceMemoryCommitment(Device @device, DeviceMemory @memory, ulong* @pCommittedMemoryInBytes);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetBufferMemoryRequirements(Device @device, Buffer @buffer, MemoryRequirements* @pMemoryRequirements);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result BindBufferMemory(Device @device, Buffer @buffer, DeviceMemory @memory, ulong @memoryOffset);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetImageMemoryRequirements(Device @device, Image @image, MemoryRequirements* @pMemoryRequirements);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result BindImageMemory(Device @device, Image @image, DeviceMemory @memory, ulong @memoryOffset);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetImageSparseMemoryRequirements(Device @device, Image @image, uint* @pSparseMemoryRequirementCount, SparseImageMemoryRequirements* @pSparseMemoryRequirements);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice @physicalDevice, Format @format, ImageType @type, SampleCountFlags @samples, ImageUsageFlags @usage, ImageTiling @tiling, uint* @pPropertyCount, SparseImageFormatProperties* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result QueueBindSparse(Queue @queue, uint @bindInfoCount, BindSparseInfo* @pBindInfo, Fence @fence);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateFence(Device @device, FenceCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Fence* @pFence);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyFence(Device @device, Fence @fence, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result ResetFences(Device @device, uint @fenceCount, Fence* @pFences);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetFenceStatus(Device @device, Fence @fence);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result WaitForFences(Device @device, uint @fenceCount, Fence* @pFences, uint @waitAll, ulong @timeout);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateSemaphore(Device @device, SemaphoreCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Semaphore* @pSemaphore);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroySemaphore(Device @device, Semaphore @semaphore, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateEvent(Device @device, EventCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Event* @pEvent);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyEvent(Device @device, Event @event, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetEventStatus(Device @device, Event @event);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result SetEvent(Device @device, Event @event);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result ResetEvent(Device @device, Event @event);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateQueryPool(Device @device, QueryPoolCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, QueryPool* @pQueryPool);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyQueryPool(Device @device, QueryPool @queryPool, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetQueryPoolResults(Device @device, QueryPool @queryPool, uint @firstQuery, uint @queryCount, UIntPtr @dataSize, IntPtr* @pData, ulong @stride, QueryResultFlags @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateBuffer(Device @device, BufferCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Buffer* @pBuffer);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyBuffer(Device @device, Buffer @buffer, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateBufferView(Device @device, BufferViewCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, BufferView* @pView);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyBufferView(Device @device, BufferView @bufferView, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateImage(Device @device, ImageCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Image* @pImage);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyImage(Device @device, Image @image, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetImageSubresourceLayout(Device @device, Image @image, ImageSubresource* @pSubresource, SubresourceLayout* @pLayout);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateImageView(Device @device, ImageViewCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, ImageView* @pView);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyImageView(Device @device, ImageView @imageView, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateShaderModule(Device @device, ShaderModuleCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, ShaderModule* @pShaderModule);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyShaderModule(Device @device, ShaderModule @shaderModule, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreatePipelineCache(Device @device, PipelineCacheCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, PipelineCache* @pPipelineCache);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyPipelineCache(Device @device, PipelineCache @pipelineCache, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPipelineCacheData(Device @device, PipelineCache @pipelineCache, UIntPtr* @pDataSize, IntPtr* @pData);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result MergePipelineCaches(Device @device, PipelineCache @dstCache, uint @srcCacheCount, PipelineCache* @pSrcCaches);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateGraphicsPipelines(Device @device, PipelineCache @pipelineCache, uint @createInfoCount, GraphicsPipelineCreateInfo* @pCreateInfos, AllocationCallbacks* @pAllocator, Pipeline* @pPipelines);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateComputePipelines(Device @device, PipelineCache @pipelineCache, uint @createInfoCount, ComputePipelineCreateInfo* @pCreateInfos, AllocationCallbacks* @pAllocator, Pipeline* @pPipelines);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyPipeline(Device @device, Pipeline @pipeline, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreatePipelineLayout(Device @device, PipelineLayoutCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, PipelineLayout* @pPipelineLayout);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyPipelineLayout(Device @device, PipelineLayout @pipelineLayout, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateSampler(Device @device, SamplerCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Sampler* @pSampler);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroySampler(Device @device, Sampler @sampler, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDescriptorSetLayout(Device @device, DescriptorSetLayoutCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, DescriptorSetLayout* @pSetLayout);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyDescriptorSetLayout(Device @device, DescriptorSetLayout @descriptorSetLayout, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDescriptorPool(Device @device, DescriptorPoolCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, DescriptorPool* @pDescriptorPool);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyDescriptorPool(Device @device, DescriptorPool @descriptorPool, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result ResetDescriptorPool(Device @device, DescriptorPool @descriptorPool, uint @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result AllocateDescriptorSets(Device @device, DescriptorSetAllocateInfo* @pAllocateInfo, DescriptorSet* @pDescriptorSets);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result FreeDescriptorSets(Device @device, DescriptorPool @descriptorPool, uint @descriptorSetCount, DescriptorSet* @pDescriptorSets);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr UpdateDescriptorSets(Device @device, uint @descriptorWriteCount, WriteDescriptorSet* @pDescriptorWrites, uint @descriptorCopyCount, CopyDescriptorSet* @pDescriptorCopies);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateFramebuffer(Device @device, FramebufferCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, Framebuffer* @pFramebuffer);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyFramebuffer(Device @device, Framebuffer @framebuffer, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateRenderPass(Device @device, RenderPassCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, RenderPass* @pRenderPass);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyRenderPass(Device @device, RenderPass @renderPass, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr GetRenderAreaGranularity(Device @device, RenderPass @renderPass, Extent2D* @pGranularity);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateCommandPool(Device @device, CommandPoolCreateInfo* @pCreateInfo, AllocationCallbacks* @pAllocator, CommandPool* @pCommandPool);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyCommandPool(Device @device, CommandPool @commandPool, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result ResetCommandPool(Device @device, CommandPool @commandPool, CommandPoolResetFlags @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result AllocateCommandBuffers(Device @device, CommandBufferAllocateInfo* @pAllocateInfo, CommandBuffer* @pCommandBuffers);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr FreeCommandBuffers(Device @device, CommandPool @commandPool, uint @commandBufferCount, CommandBuffer* @pCommandBuffers);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result BeginCommandBuffer(CommandBuffer @commandBuffer, CommandBufferBeginInfo* @pBeginInfo);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result EndCommandBuffer(CommandBuffer @commandBuffer);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result ResetCommandBuffer(CommandBuffer @commandBuffer, CommandBufferResetFlags @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBindPipeline(CommandBuffer @commandBuffer, PipelineBindPoint @pipelineBindPoint, Pipeline @pipeline);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetViewport(CommandBuffer @commandBuffer, uint @firstViewport, uint @viewportCount, Viewport* @pViewports);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetScissor(CommandBuffer @commandBuffer, uint @firstScissor, uint @scissorCount, Rect2D* @pScissors);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetLineWidth(CommandBuffer @commandBuffer, float @lineWidth);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetDepthBias(CommandBuffer @commandBuffer, float @depthBiasConstantFactor, float @depthBiasClamp, float @depthBiasSlopeFactor);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetBlendConstants(CommandBuffer @commandBuffer, float @blendConstants);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetDepthBounds(CommandBuffer @commandBuffer, float @minDepthBounds, float @maxDepthBounds);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetStencilCompareMask(CommandBuffer @commandBuffer, StencilFaceFlags @faceMask, uint @compareMask);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetStencilWriteMask(CommandBuffer @commandBuffer, StencilFaceFlags @faceMask, uint @writeMask);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetStencilReference(CommandBuffer @commandBuffer, StencilFaceFlags @faceMask, uint @reference);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBindDescriptorSets(CommandBuffer @commandBuffer, PipelineBindPoint @pipelineBindPoint, PipelineLayout @layout, uint @firstSet, uint @descriptorSetCount, DescriptorSet* @pDescriptorSets, uint @dynamicOffsetCount, uint* @pDynamicOffsets);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBindIndexBuffer(CommandBuffer @commandBuffer, Buffer @buffer, ulong @offset, IndexType @indexType);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBindVertexBuffers(CommandBuffer @commandBuffer, uint @firstBinding, uint @bindingCount, Buffer* @pBuffers, ulong* @pOffsets);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDraw(CommandBuffer @commandBuffer, uint @vertexCount, uint @instanceCount, uint @firstVertex, uint @firstInstance);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDrawIndexed(CommandBuffer @commandBuffer, uint @indexCount, uint @instanceCount, uint @firstIndex, int @vertexOffset, uint @firstInstance);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDrawIndirect(CommandBuffer @commandBuffer, Buffer @buffer, ulong @offset, uint @drawCount, uint @stride);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDrawIndexedIndirect(CommandBuffer @commandBuffer, Buffer @buffer, ulong @offset, uint @drawCount, uint @stride);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDispatch(CommandBuffer @commandBuffer, uint @x, uint @y, uint @z);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdDispatchIndirect(CommandBuffer @commandBuffer, Buffer @buffer, ulong @offset);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdCopyBuffer(CommandBuffer @commandBuffer, Buffer @srcBuffer, Buffer @dstBuffer, uint @regionCount, BufferCopy* @pRegions);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdCopyImage(CommandBuffer @commandBuffer, Image @srcImage, ImageLayout @srcImageLayout, Image @dstImage, ImageLayout @dstImageLayout, uint @regionCount, ImageCopy* @pRegions);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBlitImage(CommandBuffer @commandBuffer, Image @srcImage, ImageLayout @srcImageLayout, Image @dstImage, ImageLayout @dstImageLayout, uint @regionCount, ImageBlit* @pRegions, Filter @filter);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdCopyBufferToImage(CommandBuffer @commandBuffer, Buffer @srcBuffer, Image @dstImage, ImageLayout @dstImageLayout, uint @regionCount, BufferImageCopy* @pRegions);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdCopyImageToBuffer(CommandBuffer @commandBuffer, Image @srcImage, ImageLayout @srcImageLayout, Buffer @dstBuffer, uint @regionCount, BufferImageCopy* @pRegions);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdUpdateBuffer(CommandBuffer @commandBuffer, Buffer @dstBuffer, ulong @dstOffset, ulong @dataSize, uint* @pData);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdFillBuffer(CommandBuffer @commandBuffer, Buffer @dstBuffer, ulong @dstOffset, ulong @size, uint @data);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdClearColorImage(CommandBuffer @commandBuffer, Image @image, ImageLayout @imageLayout, ClearColorValue* @pColor, uint @rangeCount, ImageSubresourceRange* @pRanges);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdClearDepthStencilImage(CommandBuffer @commandBuffer, Image @image, ImageLayout @imageLayout, ClearDepthStencilValue* @pDepthStencil, uint @rangeCount, ImageSubresourceRange* @pRanges);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdClearAttachments(CommandBuffer @commandBuffer, uint @attachmentCount, ClearAttachment* @pAttachments, uint @rectCount, ClearRect* @pRects);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdResolveImage(CommandBuffer @commandBuffer, Image @srcImage, ImageLayout @srcImageLayout, Image @dstImage, ImageLayout @dstImageLayout, uint @regionCount, ImageResolve* @pRegions);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdSetEvent(CommandBuffer @commandBuffer, Event @event, PipelineStageFlags @stageMask);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdResetEvent(CommandBuffer @commandBuffer, Event @event, PipelineStageFlags @stageMask);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdWaitEvents(CommandBuffer @commandBuffer, uint @eventCount, Event* @pEvents, PipelineStageFlags @srcStageMask, PipelineStageFlags @dstStageMask, uint @memoryBarrierCount, MemoryBarrier* @pMemoryBarriers, uint @bufferMemoryBarrierCount, BufferMemoryBarrier* @pBufferMemoryBarriers, uint @imageMemoryBarrierCount, ImageMemoryBarrier* @pImageMemoryBarriers);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdPipelineBarrier(CommandBuffer @commandBuffer, PipelineStageFlags @srcStageMask, PipelineStageFlags @dstStageMask, DependencyFlags @dependencyFlags, uint @memoryBarrierCount, MemoryBarrier* @pMemoryBarriers, uint @bufferMemoryBarrierCount, BufferMemoryBarrier* @pBufferMemoryBarriers, uint @imageMemoryBarrierCount, ImageMemoryBarrier* @pImageMemoryBarriers);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBeginQuery(CommandBuffer @commandBuffer, QueryPool @queryPool, uint @query, QueryControlFlags @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdEndQuery(CommandBuffer @commandBuffer, QueryPool @queryPool, uint @query);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdResetQueryPool(CommandBuffer @commandBuffer, QueryPool @queryPool, uint @firstQuery, uint @queryCount);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdWriteTimestamp(CommandBuffer @commandBuffer, PipelineStageFlags @pipelineStage, QueryPool @queryPool, uint @query);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdCopyQueryPoolResults(CommandBuffer @commandBuffer, QueryPool @queryPool, uint @firstQuery, uint @queryCount, Buffer @dstBuffer, ulong @dstOffset, ulong @stride, QueryResultFlags @flags);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdPushConstants(CommandBuffer @commandBuffer, PipelineLayout @layout, ShaderStageFlags @stageFlags, uint @offset, uint @size, IntPtr* @pValues);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdBeginRenderPass(CommandBuffer @commandBuffer, RenderPassBeginInfo* @pRenderPassBegin, SubpassContents @contents);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdNextSubpass(CommandBuffer @commandBuffer, SubpassContents @contents);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdEndRenderPass(CommandBuffer @commandBuffer);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr CmdExecuteCommands(CommandBuffer @commandBuffer, uint @commandBufferCount, CommandBuffer* @pCommandBuffers);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateAndroidSurfaceKhr(Instance @instance, AndroidSurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceDisplayPropertiesKhr(PhysicalDevice @physicalDevice, uint* @pPropertyCount, DisplayPropertiesKhr* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceDisplayPlanePropertiesKhr(PhysicalDevice @physicalDevice, uint* @pPropertyCount, DisplayPlanePropertiesKhr* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetDisplayPlaneSupportedDisplaysKhr(PhysicalDevice @physicalDevice, uint @planeIndex, uint* @pDisplayCount, DisplayKhr* @pDisplays);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetDisplayModePropertiesKhr(PhysicalDevice @physicalDevice, DisplayKhr @display, uint* @pPropertyCount, DisplayModePropertiesKhr* @pProperties);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDisplayModeKhr(PhysicalDevice @physicalDevice, DisplayKhr @display, DisplayModeCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, DisplayModeKhr* @pMode);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetDisplayPlaneCapabilitiesKhr(PhysicalDevice @physicalDevice, DisplayModeKhr @mode, uint @planeIndex, DisplayPlaneCapabilitiesKhr* @pCapabilities);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDisplayPlaneSurfaceKhr(Instance @instance, DisplaySurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateSharedSwapchainsKhr(Device @device, uint @swapchainCount, SwapchainCreateInfoKhr* @pCreateInfos, AllocationCallbacks* @pAllocator, SwapchainKhr* @pSwapchains);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateMirSurfaceKhr(Instance @instance, MirSurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern uint GetPhysicalDeviceMirPresentationSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex, IntPtr* @connection);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroySurfaceKhr(Instance @instance, SurfaceKhr @surface, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceSurfaceSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex, SurfaceKhr @surface, uint* @pSupported);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceSurfaceCapabilitiesKhr(PhysicalDevice @physicalDevice, SurfaceKhr @surface, SurfaceCapabilitiesKhr* @pSurfaceCapabilities);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceSurfaceFormatsKhr(PhysicalDevice @physicalDevice, SurfaceKhr @surface, uint* @pSurfaceFormatCount, SurfaceFormatKhr* @pSurfaceFormats);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetPhysicalDeviceSurfacePresentModesKhr(PhysicalDevice @physicalDevice, SurfaceKhr @surface, uint* @pPresentModeCount, PresentModeKhr* @pPresentModes);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateSwapchainKhr(Device @device, SwapchainCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SwapchainKhr* @pSwapchain);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroySwapchainKhr(Device @device, SwapchainKhr @swapchain, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result GetSwapchainImagesKhr(Device @device, SwapchainKhr @swapchain, uint* @pSwapchainImageCount, Image* @pSwapchainImages);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result AcquireNextImageKhr(Device @device, SwapchainKhr @swapchain, ulong @timeout, Semaphore @semaphore, Fence @fence, uint* @pImageIndex);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result QueuePresentKhr(Queue @queue, PresentInfoKhr* @pPresentInfo);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateWaylandSurfaceKhr(Instance @instance, WaylandSurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern uint GetPhysicalDeviceWaylandPresentationSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex, IntPtr* @display);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateWin32SurfaceKhr(Instance @instance, Win32SurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern uint GetPhysicalDeviceWin32PresentationSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateXlibSurfaceKhr(Instance @instance, XlibSurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern uint GetPhysicalDeviceXlibPresentationSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex, IntPtr* @dpy, IntPtr @visualID);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateXcbSurfaceKhr(Instance @instance, XcbSurfaceCreateInfoKhr* @pCreateInfo, AllocationCallbacks* @pAllocator, SurfaceKhr* @pSurface);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern uint GetPhysicalDeviceXcbPresentationSupportKhr(PhysicalDevice @physicalDevice, uint @queueFamilyIndex, IntPtr* @connection, IntPtr @visual_id);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern Result CreateDebugReportCallbackExt(Instance @instance, DebugReportCallbackCreateInfoExt* @pCreateInfo, AllocationCallbacks* @pAllocator, DebugReportCallbackExt* @pCallback);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DestroyDebugReportCallbackExt(Instance @instance, DebugReportCallbackExt @callback, AllocationCallbacks* @pAllocator);
        [DllImport(VulkanLibrary, CallingConvention = CallingConvention.StdCall)]
        internal static unsafe extern IntPtr DebugReportMessageExt(Instance @instance, DebugReportFlagsExt @flags, DebugReportObjectTypeExt @objectType, ulong @object, UIntPtr @location, int @messageCode, char* @pLayerPrefix, char* @pMessage);
    }
}