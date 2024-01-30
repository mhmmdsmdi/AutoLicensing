// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentLicensing;
using FluentLicensing.Generator;

var keySize = 2 * 1024;
var sampleData = Encoding.UTF8.GetBytes("My Name Is Mohammad");

// =============================== AES

// =============================== Test Public and Private Key

//var keyGenerator = new RSACryptoServiceProvider(keySize);
//var privateKey = keyGenerator.ToXmlString(true);
//var publicKey = keyGenerator.ToXmlString(false);

//var privateCrypto = new RSACryptoServiceProvider(keySize);
//privateCrypto.FromXmlString(privateKey);
//var privateEncrypted = privateCrypto.Encrypt(sampleData, false);
//var privateDecrypted = privateCrypto.Decrypt(privateEncrypted, false);

//var publicCrypto = new RSACryptoServiceProvider(keySize);
//publicCrypto.FromXmlString(publicKey);
//var publicEncrypted = publicCrypto.Encrypt(sampleData, false);
//var publicDecrypted = publicCrypto.Decrypt(publicEncrypted, false);

// =============================== Generator
//var licenseGenerator = new LicenseGenerator(keySize);

//var privateKey = licenseGenerator.PrivateKey.ToBase64();
//var publicKey = licenseGenerator.PublicKey.ToBase64();
//Console.WriteLine("Private EncryptKey: ");
//Console.WriteLine(privateKey);
//Console.WriteLine();

//Console.WriteLine("Public EncryptKey: ");
//Console.WriteLine(publicKey);
//Console.WriteLine();

//var license = licenseGenerator.Generate(new LicenseData("Test Company")
//{
//    Products = new List<ProductLicense>()
//    {
//        new()
//        {
//            Features = new Dictionary<string, bool>()
//            {
//                {"Feature1",true},
//                {"Feature2",true},
//                {"Feature3",false},
//            },
//            Attributes = new List<LicenseAttribute>()
//            {
//                new("Insert Limitation",1_000),
//                new("User Limitation",2),
//            },
//            Expiry = DateTime.Now.AddDays(180)
//        },
//        new()
//        {
//            Features = new Dictionary<string, bool>()
//            {
//                {"Feature4",true},
//                {"Feature5",true},
//                {"Feature6",false},
//            },
//            Attributes = new List<LicenseAttribute>()
//            {
//                new("Insert Limitation",1_000),
//            },
//            Expiry = DateTime.Now.AddDays(200)
//        }
//    }
//});

//Console.WriteLine("License :");
//Console.WriteLine(license.Key);
//Console.WriteLine();

//var licenseManager = new LicenseManager(EncryptKey.FromBase64(publicKey, keySize), new License(license.Key));

//var data = licenseManager.Data;