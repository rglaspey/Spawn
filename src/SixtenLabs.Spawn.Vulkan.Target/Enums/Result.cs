namespace SixtenLabs.Spawn.Vulkan.Target
{
    public enum Result
    {
        SUCCESS = 0,
        NotReady = 1,
        TIMEOUT = 2,
        EventSet = 3,
        EventReset = 4,
        INCOMPLETE = 5,
        ErrorOutOfHostMemory = -1,
        ErrorOutOfDeviceMemory = -2,
        ErrorInitializationFailed = -3,
        ErrorDeviceLost = -4,
        ErrorMemoryMapFailed = -5,
        ErrorLayerNotPresent = -6,
        ErrorExtensionNotPresent = -7,
        ErrorFeatureNotPresent = -8,
        ErrorIncompatibleDriver = -9,
        ErrorTooManyObjects = -10,
        ErrorFormatNotSupported = -11
    }
}