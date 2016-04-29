using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    //public struct ImageBlit
    //{
    //    public ImageSubresourceLayers srcSubresource;
    //    public Offset3D[] srcOffsets;
    //    public ImageSubresourceLayers dstSubresource;
    //    public Offset3D[] dstOffsets;
    //}

		// adding array fields makes this a managed class - how to handle this?

	public partial struct ImageBlit
	{
		public ImageSubresourceLayers SourceSubresource;

		public struct SourceOffsetsArray
		{
			public Offset3D Value0;

			public Offset3D Value1;
		}

		public SourceOffsetsArray SourceOffsets;

		public ImageSubresourceLayers DestinationSubresource;

		public struct DestinationOffsetsArray
		{
			public Offset3D Value0;

			public Offset3D Value1;
		}

		public DestinationOffsetsArray DestinationOffsets;
	}
}