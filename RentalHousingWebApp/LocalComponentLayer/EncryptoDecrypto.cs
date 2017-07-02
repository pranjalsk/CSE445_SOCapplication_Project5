using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalHousingWebApp.LocalComponentLayer
{
    public class EncryptoDecrypto
    {
        EncryptoLibrary.CryptoClass proxy = new EncryptoLibrary.CryptoClass();

        public string encrypto(string encryptInput)
        {
            return proxy.encrypto(encryptInput);
        }

        public string decrypto(string decryptInput)
        {
            return proxy.decrypto(decryptInput);
        }


    }
}