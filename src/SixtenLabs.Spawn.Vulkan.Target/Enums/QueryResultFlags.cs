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
  public enum QueryResultFlags
  {
    /// <summary> 
    /// Results of the queries are written to the destination buffer as 64-bit values
    /// </summary> 
    QueryResult64Bit = 0,

    /// <summary> 
    /// Results of the queries are waited on before proceeding with the result copy
    /// </summary> 
    QueryResultWaitBit = 1,

    /// <summary> 
    /// Besides the results of the query, the availability of the results is also written
    /// </summary> 
    QueryResultWithAvailabilityBit = 2,

    /// <summary> 
    /// Copy the partial results of the query even if the final results aren't available
    /// </summary> 
    QueryResultPartialBit = 3
  }
}