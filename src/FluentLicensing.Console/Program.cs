// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

var aaa = RSA.Create(2048);

var rsa = new RSACryptoServiceProvider(2048);
var privateKey = rsa.ToXmlString(true);
var publicKey = rsa.ToXmlString(false);

Console.WriteLine("Private Key: " + Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey)) + Environment.NewLine);
Console.WriteLine("Public Key: " + Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey)) + Environment.NewLine);

var text = "Stringa da Criptare@#[]123123";
Console.WriteLine("Text to encrypt: " + Environment.NewLine + text + Environment.NewLine);
var enc = Encrypt(text);
Console.WriteLine("Encrypted Text: " + Environment.NewLine + enc + Environment.NewLine);
var dec = Decrypt(enc);
Console.WriteLine("Decrypted Text: " + Environment.NewLine + dec + Environment.NewLine);

string Encrypt(string data)
{
    RSACryptoServiceProvider rsa = new();
    rsa.FromXmlString(publicKey);

    byte[] dataToEncrypt = Encoding.ASCII.GetBytes(data);
    byte[] encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();

    return Convert.ToBase64String(encryptedByteArray);
}

string Decrypt(string data)
{
    RSACryptoServiceProvider rsa = new();
    rsa.FromXmlString(privateKey);

    byte[] dataByte = Convert.FromBase64String(data);
    byte[] decryptedByte = rsa.Decrypt(dataByte, false);

    return Encoding.UTF8.GetString(decryptedByte);
}