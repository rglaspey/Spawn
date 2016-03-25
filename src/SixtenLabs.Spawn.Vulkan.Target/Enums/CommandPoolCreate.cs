using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
	[Flags]
	public enum CommandPoolCreate : int
	{
		CommandPoolCreateTransientBit = 1 << 0,
		CommandPoolCreateResetCommandBufferBit = 1 << 1
	}
}