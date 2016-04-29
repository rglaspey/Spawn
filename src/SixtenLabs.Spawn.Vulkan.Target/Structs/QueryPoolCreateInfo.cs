using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct QueryPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public QueryType queryType;
        public uint queryCount;
        public QueryPipelineStatisticFlags pipelineStatistics;
    }
}