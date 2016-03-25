using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum AttachmentDescription : int
    {
        AttachmentDescriptionMayAliasBit = 1 << 0
    }
}