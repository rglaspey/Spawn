namespace SixtenLabs.Spawn.Vulkan.Target
{
    public enum SystemAllocationScope : int
    {
        SystemAllocationScopeCommand = 0,
        SystemAllocationScopeObject = 1,
        SystemAllocationScopeCache = 2,
        SystemAllocationScopeDevice = 3,
        SystemAllocationScopeInstance = 4
    }
}