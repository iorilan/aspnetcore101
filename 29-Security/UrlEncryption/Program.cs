using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleUrl = "param=324?param2=aaabb";
            var encrypt = UrlEncryption.Encrypt(sampleUrl);
            Console.WriteLine(encrypt);

            var decrypt = UrlEncryption.Decrypt(encrypt);
            Console.WriteLine(decrypt);
        }
    }
}
