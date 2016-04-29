using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct BindSparseInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public uint bufferBindCount;
        public SparseBufferMemoryBindInfo pBufferBinds;
        public uint imageOpaqueBindCount;
        public SparseImageOpaqueMemoryBindInfo pImageOpaqueBinds;
        public uint imageBindCount;
        public SparseImageMemoryBindInfo pImageBinds;
        public uint signalSemaphoreCount;
        public Semaphore pSignalSemaphores;
    }
}