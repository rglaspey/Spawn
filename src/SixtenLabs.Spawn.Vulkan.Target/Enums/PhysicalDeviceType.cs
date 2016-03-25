namespace SixtenLabs.Spawn.Vulkan.Target
{
    public enum PhysicalDeviceType : int
    {
        PhysicalDeviceTypeOther = 0,
        PhysicalDeviceTypeIntegratedGpu = 1,
        PhysicalDeviceTypeDiscreteGpu = 2,
        PhysicalDeviceTypeVirtualGpu = 3,
        PhysicalDeviceTypeCpu = 4
    }
}