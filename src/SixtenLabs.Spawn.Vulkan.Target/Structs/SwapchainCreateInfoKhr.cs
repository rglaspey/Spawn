using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SwapchainCreateInfoKhr
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public SurfaceKhr surface;
        public uint minImageCount;
        public Format imageFormat;
        public ColorSpaceKhr imageColorSpace;
        public Extent2D imageExtent;
        public uint imageArrayLayers;
        public ImageUsageFlags imageUsage;
        public SharingMode imageSharingMode;
        public uint queueFamilyIndexCount;
        public uint pQueueFamilyIndices;
        public SurfaceTransformFlagsKhr preTransform;
        public CompositeAlphaFlagsKhr compositeAlpha;
        public PresentModeKhr presentMode;
        public uint clipped;
        public SwapchainKhr oldSwapchain;
    }
}