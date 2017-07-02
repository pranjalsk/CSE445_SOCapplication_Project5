using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public class CryptoClass
    {
        static ServiceReferenceEncryption.ServiceClient proxy = new ServiceReferenceEncryption.ServiceClient();

        public static string encrypto(string encryptInput) {
           return proxy.Encrypt(encryptInput);    
        }

        public static string decrypto(string decryptInput) {
            return proxy.Decrypt(decryptInput);
        }

    }
}
