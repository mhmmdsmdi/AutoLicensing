namespace AutoLicensing.Extensions;

public static class Confuser
{
    public static byte[] ConfusingBytes = { 2, 43, 2, 54, 199, 3, 43 };

    internal static byte[] UnConfuse(this byte[] bytes)
    {
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] ^= ConfusingBytes[i % ConfusingBytes.Length];

        return bytes;
    }
}