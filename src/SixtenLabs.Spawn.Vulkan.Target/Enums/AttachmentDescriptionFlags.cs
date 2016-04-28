using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum AttachmentDescriptionFlags
    {
        /// <summary>
                /// The attachment may alias physical memory of another attachment in the same render pass
                /// </summary>
        AttachmentDescriptionMayAliasBit = 0
    }
}