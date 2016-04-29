using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SubmitInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public PipelineStageFlags pWaitDstStageMask;
        public uint commandBufferCount;
        public CommandBuffer pCommandBuffers;
        public uint signalSemaphoreCount;
        public Semaphore pSignalSemaphores;
    }
}