using System;

namespace SixtenLabs.Spawn.Test
{
	/// <summary>
	/// Small static utility class to help formatting 
	/// strings with newlines and indents for unit testing.
	/// 
	/// add using static SixtenLabs.Spawn.Test.OutputStringHelper;
	/// to the file where you want to use these so you dont have to prefix the class name.
	/// </summary>
	public static class OutputStringHelper
	{
		/// <summary>
		/// Opening Brace {
		/// </summary>
		public const string OB = "{";

		/// <summary>
		/// Closing Brace }
		/// </summary>
		public const string CB = "}";

		/// <summary>
		/// Indent with 4 spaces
		/// </summary>
		public const string I4 = "    ";

		/// <summary>
		/// Indent with 8 spaces
		/// </summary>
		public const string I8 = "        ";

		/// <summary>
		/// Indent with 12 spaces
		/// </summary>
		public const string I12 = "            ";

		/// <summary>
		/// A newline
		/// </summary>
		public static readonly string NL = Environment.NewLine;
	}
}
