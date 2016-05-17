using System.Globalization;
using System.Text;

namespace SixtenLabs.Spawn
{
	public static class StringExtensions
	{
		/// <summary>
		/// Converts a string to title case using a seperator.
		/// </summary>
		/// <param name="stringToConvert"></param>
		/// <param name="seperator"></param>
		/// <returns></returns>
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
