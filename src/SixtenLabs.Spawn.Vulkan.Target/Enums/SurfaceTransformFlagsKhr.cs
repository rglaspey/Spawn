using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum SurfaceTransformFlagsKhr
    {
        SurfaceTransformIdentityBitKhr = 0,
        SurfaceTransformRotate90BitKhr = 1,
        SurfaceTransformRotate180BitKhr = 2,
        SurfaceTransformRotate270BitKhr = 3,
        SurfaceTransformHorizontalMirrorBitKhr = 4,
        SurfaceTransformHorizontalMirrorRotate90BitKhr = 5,
        SurfaceTransformHorizontalMirrorRotate180BitKhr = 6,
        SurfaceTransformHorizontalMirrorRotate270BitKhr = 7,
        SurfaceTransformInheritBitKhr = 8
    }
}