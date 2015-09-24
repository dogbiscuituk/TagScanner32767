namespace TagScanner
{
	public static class StringUtilities
	{
		public static string AmpersandEscape(this string s)
		{
			return s.Replace("&", "&&");
		}

		public static string AmpersandUnescape(this string s)
		{
			return s.Replace("&&", "&");
		}
	}
}
