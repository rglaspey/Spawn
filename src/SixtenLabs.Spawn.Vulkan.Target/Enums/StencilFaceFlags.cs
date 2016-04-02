﻿using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
  /// <summary>
  /// *** Do Not Edit ***
  /// This file was generated by the Spawn Code Generator.
  /// https://github.com/SixtenLabs/Spawn
  /// 
  /// Generated from the vk.xml registry file from Khronos Group.
  /// https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/1.0/src/spec/vk.xml
  /// 
  /// </summary>
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