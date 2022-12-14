using System.Runtime.InteropServices;

namespace Crawler.Net.Url;

public class URLCanonicalizer
{
	private static bool _haltOnError = false;
	public bool HaltonError
	{
		set { _haltOnError = value; }
	}
	
	public static String GetCanonicalURL(String url) {
		return GetCanonicalURL(url, null);
	}

	public static String GetCanonicalURL(String href, String context){
		return GetCanonicalURL(href, context, CharSet.Unicode);
	}

	public static String GetCanonicalURL(String href, String context, CharSet charset)
	{
		Uri canonicalURL = new Uri(new Uri(context == null ? "" : context), href);
		String host = canonicalURL.Host;
		if (String.Equals(host, ""))
			return null;
		String path = canonicalURL.AbsolutePath;
		
		/*
		 * Normalize: no empty segments (i.e., "//"), no segments equal to
		 * ".", and no segments equal to ".." that are preceded by a segment
		 * not equal to "..".
		 */
		path = path.Replace("\\", "/");
		path = path.Replace(Char.ConvertFromUtf32(12288), "%E3%80%80");
		path = path.Replace(Char.ConvertFromUtf32(32), "%20");
		path = new Uri(path).AbsolutePath;

	}
}