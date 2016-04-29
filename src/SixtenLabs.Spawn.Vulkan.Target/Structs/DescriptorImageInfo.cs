using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct DescriptorImageInfo
    {
        public Sampler sampler;
        public ImageView imageView;
        public ImageLayout imageLayout;
    }
}