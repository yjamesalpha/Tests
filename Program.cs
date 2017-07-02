using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Generators;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        public static AsymmetricCipherKeyPair GenerateKeys(int keySizeInBits)
        {
            var r = new RsaKeyPairGenerator();
            r.Init(new KeyGenerationParameters(new SecureRandom(),
keySizeInBits));
            var keys = r.GenerateKeyPair();
            return keys;
        }



        static void Main(string[] args)
        {
            var keys = GenerateKeys(2048);


            var publicKey = keys.Public.ToString();

            var textWriter = new StreamWriter("N:\\Websites\\WebSite1\\Tests\\RSA\\RSAEncryptDecrypt\\private.key");
            var pemWriter = new PemWriter(textWriter);
            pemWriter.WriteObject(keys.Private);
            pemWriter.Writer.Flush();
            textWriter.Close();


            textWriter = new StreamWriter("N:\\Websites\\WebSite1\\Tests\\RSA\\RSAEncryptDecrypt\\public.key");
            pemWriter = new PemWriter(textWriter);
            pemWriter.WriteObject(keys.Public);
            pemWriter.Writer.Flush();
            textWriter.Close();

            Console.ReadKey();


        }
    }
}
