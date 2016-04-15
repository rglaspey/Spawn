using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan
{
	public static class Extensions
	{
		public static string FirstLetterToLowercase(this string word)
		{
			return char.ToLowerInvariant(word[0]) + word.Substring(1);
		}

		public static string TranslateVulkanName(this string vulkanName)
		{
			var name = vulkanName;

			if (vulkanName.StartsWith("VK_"))
			{
				name = vulkanName.Substring(3, name.Length - 3);
			}
			else if (vulkanName.ToLower().StartsWith("vk") )
			{
				name = vulkanName.Remove(0, 2);
			}
			
			if (name.Contains("FlagBits"))
			{
				name = name.Replace("FlagBits", string.Empty);
			}

			if (name.Contains("Flags"))
			{
				name = name.Replace("Flags", string.Empty);
			}

			if (name.Contains("_"))
			{
				name = name.ConvertToTitleCase('_');
			}

			foreach (var nameCorrection in NameCorrections)
			{
				if (name.Contains(nameCorrection.Key))
				{
					name = name.Replace(nameCorrection.Key, nameCorrection.Value);
				}
			}

			return name;
		}
				
		private static IDictionary<string, string> NameCorrections { get; } = new Dictionary<string, string>()
		{
			{ "API", "Api" },
			{ "EXT", "Ext" },
			{ "KHR", "Khr" },
		};
	}
}
