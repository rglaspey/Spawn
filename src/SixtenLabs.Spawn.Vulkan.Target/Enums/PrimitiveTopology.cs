namespace SixtenLabs.Spawn.Vulkan.Target
{
    public enum PrimitiveTopology : int
    {
        PrimitiveTopologyPointList = 0,
        PrimitiveTopologyLineList = 1,
        PrimitiveTopologyLineStrip = 2,
        PrimitiveTopologyTriangleList = 3,
        PrimitiveTopologyTriangleStrip = 4,
        PrimitiveTopologyTriangleFan = 5,
        PrimitiveTopologyLineListWithAdjacency = 6,
        PrimitiveTopologyLineStripWithAdjacency = 7,
        PrimitiveTopologyTriangleListWithAdjacency = 8,
        PrimitiveTopologyTriangleStripWithAdjacency = 9,
        PrimitiveTopologyPatchList = 10
    }
}