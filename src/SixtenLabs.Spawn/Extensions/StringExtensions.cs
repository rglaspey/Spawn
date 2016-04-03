using System.Globalization;
using System.Text;

namespace SixtenLabs.Spawn
{
	public static class StringExtensions
	{
		public static string ConvertToTitleCase(this string stringToConvert, char seperator)
		{
			var textInfo = new CultureInfo("en-US", false).TextInfo;
			var words = stringToConvert.Split(seperator);

			var builder = new StringBuilder();

			foreach(var word in words)
			{
				builder.Append(textInfo.ToTitleCase(word.ToLower()));
			}
			
			return builder.ToString();
		}
	}
}
