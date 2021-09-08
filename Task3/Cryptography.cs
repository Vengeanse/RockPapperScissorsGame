using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Task3
{
    class Cryptography
    {
        private string secretKey;

        public void CalculateSecretKey()
        {
            byte[] byteArray = new byte[16];
            RNGCryptoServiceProvider.Create().GetBytes(byteArray);
            secretKey = BitConverter.ToString(byteArray).Replace("-", "");
        }

        public int GetComputerChoise(string[] arguments)
        {
            return RNGCryptoServiceProvider.GetInt32(arguments.Length);
        }

        public string GetHMAC(string word)
        {
            string keyWord = secretKey + word;

            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);
            byte[] input = Encoding.ASCII.GetBytes(keyWord);
            hashAlgorithm.BlockUpdate(input, 0, input.Length);
            byte[] result = new byte[32];
            hashAlgorithm.DoFinal(result, 0);
            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();

            return hashString;
        }

        public string GetSecretKey()
        {
            return secretKey;
        }
    }
}
