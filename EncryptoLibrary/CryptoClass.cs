using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncryptoLibrary
{
    public sealed class Cryption
    {
        byte[] seed = ASCIIEncoding.ASCII.GetBytes("cse44598");
        // A seed from a binary array for encryption. We could encrypt the seed to make it even more secure.
        /// <summary>
        /// Encryption function
        /// </summary>
        /// <param name="plainString"></param>
        /// <returns></returns>
        public string Encrypt(string plainString)
        { // encryption using DES       
            if (String.IsNullOrEmpty(plainString))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }

            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);
            StreamWriter sWriter = new StreamWriter(cStream);

            sWriter.Write(plainString);
            sWriter.Flush(); // Buffer flush is necessary when switching writing modes
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);
        }

        /// <summary>
        /// Decryption function
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        public string Decrypt(string encryptedString)
        { // decryption using DES 
            if (String.IsNullOrEmpty(encryptedString))
            {
                throw new ArgumentNullException("The string cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream(Convert.FromBase64String(encryptedString));
            CryptoStream cStream = new CryptoStream(memStream, saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);
            return reader.ReadLine();
        }
    }


    public class CryptoClass
    {
        Cryption proxy = new Cryption();

        public string encrypto(string encryptInput)
        {
            return proxy.Encrypt(encryptInput);
        }

        public string decrypto(string decryptInput)
        {
            return proxy.Decrypt(decryptInput);
        }

    }

}
