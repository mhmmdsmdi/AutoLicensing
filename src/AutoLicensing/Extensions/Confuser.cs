namespace AutoLicensing.Extensions;

public static class Confuser
{
    internal static byte[] UnConfuse(this byte[] bytes)
    {
        var confusingBytes = new byte[] { 2, 43, 2, 54, 199, 3, 43 };
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] ^= confusingBytes[i % confusingBytes.Length];

        return bytes;
    }
}