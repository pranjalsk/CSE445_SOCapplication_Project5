using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalHousingWebApp.LocalComponentLayer
{
    public class EncryptoDecrypto
    {

        EncryptoLibrary.CryptoClass proxy = new EncryptoLibrary.CryptoClass();
        /// <summary>
        /// Invoke encrypt method from DLL
        /// </summary>
        /// <param name="encryptInput"></param>
        /// <returns></returns>
        public string encrypto(string encryptInput)
        {
            return proxy.encrypto(encryptInput);
        }

        /// <summary>
        /// Invoke decrypt method from DLL
        /// </summary>
        /// <param name="decryptInput"></param>
        /// <returns></returns>
        public string decrypto(string decryptInput)
        {
            return proxy.decrypto(decryptInput);
        }


    }
}