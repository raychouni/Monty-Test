using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace KeyGenerator
{
    class Program
    {
        static void Main()
        {
            //CSP(cryptographic service provider) with a new 2048 bit rsa key pair
            var csp = new RSACryptoServiceProvider(2048);

            //private key
            var privKey = csp.ExportParameters(true);

            //public key
            var pubKey = csp.ExportParameters(false);

            //converting the Private key into a string
            string privKeyString;
            {
                var sw = new System.IO.StringWriter();
                //serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privKeyString = sw.ToString();
                File.WriteAllText("PrivateK.csr", privKeyString);
            }


            //converting the public key into a string
            string pubKeyString;
            {
                
                var sw = new System.IO.StringWriter();
                //serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, pubKey);
                //get the string from the stream
                pubKeyString = sw.ToString();
                File.WriteAllText("PublicK.csr", pubKeyString);
            }
        }
    }
}
