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

		public static string TakeWord(ref string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				return string.Empty;
			var p = text.IndexOf(' ');
			if (p < 0)
				p = text.Length;
			var word = text.Substring(0, p);
			text = text.Substring(p).TrimStart();
			return word;
		}
	}
}
