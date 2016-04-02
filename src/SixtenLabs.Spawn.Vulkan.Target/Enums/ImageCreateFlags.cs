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
  public enum ImageCreateFlags
  {
    /// <summary> 
    /// Image should support sparse backing
    /// </summary> 
    IMAGE_CREATE_SPARSE_BINDING_BIT = 0,

    /// <summary> 
    /// Image should support sparse backing with partial residency
    /// </summary> 
    IMAGE_CREATE_SPARSE_RESIDENCY_BIT = 1,

    /// <summary> 
    /// Image should support constent data access to physical memory ranges mapped into multiple locations of sparse images
    /// </summary> 
    IMAGE_CREATE_SPARSE_ALIASED_BIT = 2,

    /// <summary> 
    /// Allows image views to have different format than the base image
    /// </summary> 
    IMAGE_CREATE_MUTABLE_FORMAT_BIT = 3,

    /// <summary> 
    /// Allows creating image views with cube type from the created image
    /// </summary> 
    IMAGE_CREATE_CUBE_COMPATIBLE_BIT = 4
  }
}