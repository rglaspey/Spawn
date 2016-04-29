using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PresentInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public uint swapchainCount;
        public SwapchainKhr pSwapchains;
        public uint pImageIndices;
        public Result pResults;
    }
}