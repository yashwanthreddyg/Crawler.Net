namespace Crawler.Net.Util;

public class Util
{
    
    public static byte[] Long2ByteArray(long l) {
        byte[] array = new byte[8];
        int i;
        int shift;
        for (i = 0, shift = 56; i < 8; i++, shift -= 8) {
            array[i] = (byte) (0xFF & (l >> shift));
        }
        return array;
    }

    
    public static byte[] Int2ByteArray(int value)
    {
        byte[] b = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            int offset = (3 - i) * 8;
            b[i] = (byte)((value >> offset) & 0xFF);
        }
        return b;
    }

    public static void PutIntInByteArray(int value, byte[] buf, int offset) {
        for (int i = 0; i < 4; i++) {
            int valueOffset = (3 - i) * 8;
            buf[offset + i] = (byte) ((value >> valueOffset) & 0xFF);
        }
    }

    public static int ByteArray2Int(byte[] b) {
        int value = 0;
        for (int i = 0; i < 4; i++) {
            int shift = (4 - 1 - i) * 8;
            value += (b[i] & 0x000000FF) << shift;
        }
        return value;
    }

    public static long ByteArray2Long(byte[] b) {
        int value = 0;
        for (int i = 0; i < 8; i++) {
            int shift = (8 - 1 - i) * 8;
            value += (b[i] & 0x000000FF) << shift;
        }
        return value;
    }

    public static bool HasBinaryContent(String contentType) {
        String typeStr = (contentType != null) ? contentType.ToLower() : "";

        return typeStr.Contains("image") || typeStr.Contains("audio") ||
               typeStr.Contains("video") || typeStr.Contains("application");
    }

    public static Boolean HasPlainTextContent(String contentType) {
        String typeStr = (contentType != null) ? contentType.ToLower() : "";

        return typeStr.Contains("text") && !typeStr.Contains("html");
    }

    public static Boolean HasCssTextContent(String contentType) {
        String typeStr = (contentType != null) ? contentType.ToLower() : "";

        return typeStr.Contains("css");
    }

    public static bool IsValidDomainName(string name)
    {
        return Uri.CheckHostName(name) != UriHostNameType.Unknown;
    }
}