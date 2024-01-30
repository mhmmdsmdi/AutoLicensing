using AutoLicensing;
using AutoLicensing.Extensions;
using AutoLicensing.Models;

void Validate()
{
    var privateKey = "BwIAAACkAABSU0EyAAQAAAEAAQC1B9ohLvVmHotJ/AL5VDlIOpLLm2CtF9LH8+ZP8n+ejYQKo4noYoPQBlMM9EbmPbEOmsPGcDixjykRlaiVWhVvF3v9DFdDtJa70Qx/Z5V8MznTbOtHCnYiPO9auNqXgdxwgg8kQpoK4O2sLJsPAM/NmLEOrXNtCJALlTR9Qm4QoYvmRkqD6fKzvg6QmZM2q2ZVvan+q5y8sHIiU3c0C0VG9ALXPQkMdNhcckTmvdjTcBpNHtWhjD9ONXRN19siIda/0kIaDrxetQFk7FgR++D2vCeEHhTfulzqrLISE5q+hn85tzgOyA05GDiGsbXouNlXJx2DQSm1ZmsXZPP29Y7AW8eq2sS2i7t/PrImKrDNqvO0MOHYdg0h5SjIiiM1/+GiHuecWsnPbNku4xTd4/L+puwdsbNqcc6/hPJED2mroZkEx1MqrMOzdxKBtPz3YdGKLwOiTBrJGdAwFsTTq2oSzvro7EOLdMLXKYoSNysR5XXGELeUUlZeKVZ7FEhxDTQKuIC2TbWDnVJXFqqfWXtr3zpptB8R6+RwB3ODyu/dJMuwjcUGlT3sN76V6gacN7cOuJcFRplPEA25n9RTXsm3kcUkbUTL3kK/Mj24m4PRelssKCAvcZQPsan2nqT9xGV1/A2XNzJgzNgHoVQLWXgHymGjaWM70R4FkW96tgZ5KTmRaD7ESSssACMe3kqn8yjbJCkVt1vQiLVdM5AKmffZNyj5LIJ48NzsRtsN8h1msbvRoxchz38xo8EiCCwlDCs=";
    var publicKey =
        "BwIAAACkAABSU0EyAAQAAAEAAQC1B9ohLvVmHotJ/AL5VDlIOpLLm2CtF9LH8+ZP8n+ejYQKo4noYoPQBlMM9EbmPbEOmsPGcDixjykRlaiVWhVvF3v9DFdDtJa70Qx/Z5V8MznTbOtHCnYiPO9auNqXgdxwgg8kQpoK4O2sLJsPAM/NmLEOrXNtCJALlTR9Qm4QoYvmRkqD6fKzvg6QmZM2q2ZVvan+q5y8sHIiU3c0C0VG9ALXPQkMdNhcckTmvdjTcBpNHtWhjD9ONXRN19siIda/0kIaDrxetQFk7FgR++D2vCeEHhTfulzqrLISE5q+hn85tzgOyA05GDiGsbXouNlXJx2DQSm1ZmsXZPP29Y7AW8eq2sS2i7t/PrImKrDNqvO0MOHYdg0h5SjIiiM1/+GiHuecWsnPbNku4xTd4/L+puwdsbNqcc6/hPJED2mroZkEx1MqrMOzdxKBtPz3YdGKLwOiTBrJGdAwFsTTq2oSzvro7EOLdMLXKYoSNysR5XXGELeUUlZeKVZ7FEhxDTQKuIC2TbWDnVJXFqqfWXtr3zpptB8R6+RwB3ODyu/dJMuwjcUGlT3sN76V6gacN7cOuJcFRplPEA25n9RTXsm3kcUkbUTL3kK/Mj24m4PRelssKCAvcZQPsan2nqT9xGV1/A2XNzJgzNgHoVQLWXgHymGjaWM70R4FkW96tgZ5KTmRaD7ESSssACMe3kqn8yjbJCkVt1vQiLVdM5AKmffZNyj5LIJ48NzsRtsN8h1msbvRoxchz38xo8EiCCwlDCs=";
    var license = "eyJDb21wYW55TmFtZSI6IkhpaWlpIiwiUHJvZHVjdHMiOlt7Ik5hbWUiOm51bGwsIkZlYXR1cmVzIjp7IkZlYXR1cmUxIjp0cnVlLCJGZWF0dXJlMiI6dHJ1ZSwiRmVhdHVyZTMiOmZhbHNlfSwiQXR0cmlidXRlcyI6W3siS2V5IjoiSW5zZXJ0IExpbWl0YXRpb24iLCJWYWx1ZSI6IjEwMDAifSx7IktleSI6IlVzZXIgTGltaXRhdGlvbiIsIlZhbHVlIjoiMiJ9XSwiSXNzdWVEYXRlIjoiMDAwMS0wMS0wMVQwMDowMDowMCIsIkV4cGlyeURhdGUiOiIyMDI0LTA3LTI4VDE4OjMxOjQ0LjAyMTY4ODErMDM6MzAifSx7Ik5hbWUiOm51bGwsIkZlYXR1cmVzIjp7IkZlYXR1cmU0Ijp0cnVlLCJGZWF0dXJlNSI6dHJ1ZSwiRmVhdHVyZTYiOmZhbHNlfSwiQXR0cmlidXRlcyI6W3siS2V5IjoiSW5zZXJ0IExpbWl0YXRpb24iLCJWYWx1ZSI6IjEwMDAifV0sIklzc3VlRGF0ZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJFeHBpcnlEYXRlIjoiMjAyNC0wOC0xN1QxODozMTo0NC4wMjI4MzMrMDM6MzAifV0sIlNpZ25hdHVyZSI6IktoNUw4ZWpwdWZKUDlQeWdHbXBtZXQ0cVo4VXlHR2hsQlVXMWsvenZzd0hieFYxOUcyUzlGUGlkTXlpYTgvSGZmcG9ZVWVnenBMU0hUYVo0VkkvZ3R3aXNydnF6RktXVDhYRkVTRExMQ2xIUXhja0tjVlBFS2dMN2dzRjRUelRlRy9jU0ZkbndLREYzK1d5SlV3OGVQSHRiUXE4K3IwVjFKYjFOOWZvT3p1Zz0ifQ==";

    var signedLicense = License.Verifier
        .WithRsaPublicKey(publicKey)
        .LoadAndVerify(license);
}

void GenerateLicense()
{
    var key = LicenseKeyGenerator.GenerateRsaKeyPair();

    Console.WriteLine("Private Key :");
    Console.WriteLine(key.PrivateKey);
    Console.WriteLine();

    Console.WriteLine("Public Key :");
    Console.WriteLine(key.PrivateKey);
    Console.WriteLine();

    var license = License.Generator
        .WithRsaPrivateKey(key.PrivateKey)
        .WithLicense(new SignedLicense()
        {
            CompanyName = "Hiiii",
            Products = new List<Product>()
            {
                new()
                {
                    Features = new Dictionary<string, bool>()
                    {
                        {"Feature1",true},
                        {"Feature2",true},
                        {"Feature3",false},
                    },
                    Attributes = new List<LicenseAttribute>()
                    {
                        new("Insert Limitation",1_000),
                        new("User Limitation",2),
                    },
                    ExpiryDate = DateTime.Now.AddDays(180)
                },
                new()
                {
                    Features = new Dictionary<string, bool>()
                    {
                        {"Feature4",true},
                        {"Feature5",true},
                        {"Feature6",false},
                    },
                    Attributes = new List<LicenseAttribute>()
                    {
                        new("Insert Limitation",1_000),
                    },
                    ExpiryDate = DateTime.Now.AddDays(200)
                }
            }
        }).SignAndCreate();

    Console.WriteLine("License :");
    Console.WriteLine(license.Export());
}

try
{
    Validate();
}
catch (Exception e)
{
    Console.WriteLine(e);
}