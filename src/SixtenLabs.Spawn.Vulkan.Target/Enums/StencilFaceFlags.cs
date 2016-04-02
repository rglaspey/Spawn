using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  [Flags]
  public enum StencilFaceFlags
  {
    /// <summary> 
    /// Front face
    /// </summary> 
    STENCIL_FACE_FRONT_BIT = 0,

    /// <summary> 
    /// Back face
    /// </summary> 
    STENCIL_FACE_BACK_BIT = 1,

    /// <summary> 
    /// Front and back faces
    /// </summary> 
    STENCIL_FRONT_AND_BACK = 0x00000003
  }
}