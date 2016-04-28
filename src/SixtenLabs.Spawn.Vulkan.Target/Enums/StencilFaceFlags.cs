using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum StencilFaceFlags
    {
        /// <summary>
                /// Front face
                /// </summary>
        StencilFaceFrontBit = 0,
        /// <summary>
                /// Back face
                /// </summary>
        StencilFaceBackBit = 1,
        /// <summary>
                /// Front and back faces
                /// </summary>
        StencilFrontAndBack = 0x00000003
    }
}