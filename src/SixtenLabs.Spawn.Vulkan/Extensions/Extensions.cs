using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	public static class Extensions
	{
		/// <summary>
		/// There's normally not supposed to be any transformations
		/// happening in this class, but the way bitmasks are layed out
		/// in the spec is weird. A bitmask named `VkNameFlagBits` is
		/// actually refrenced as `VkNameFlags` (Except for when it isn't). 
		/// I think this has something to do with `typedef` works in c
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string GetEnumName(this string name)
		{
			if (name.EndsWith("FlagBits"))
			{
				name = name.Substring(0, name.Length - 4);
				name += "s";
			}

			return name;
		}
	}
}
