using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Alice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  var pubKey;
            string readText = File.ReadAllText("PrivateK.csr");
           
                var sr = new System.IO.StringReader(readText);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                var privKey = (RSAParameters)xs.Deserialize(sr);

                var cypherText = Encrypted_txt.Text;

               var bytesCypherText = Convert.FromBase64String(cypherText);

                //we want to decrypt, therefore we need a csp and load our private key
               var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(privKey);

                //decrypt and strip 
                var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

                //get our original plainText back
                var plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

                EncKey_txt.Text = plainTextData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var txt = Text_txt.Text;
            var PlainTextKey = EncKey_txt.Text;

            var bytesPlainTextKey = System.Text.Encoding.Unicode.GetBytes(PlainTextKey);
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(txt);

            var Decrypted = TripleDESSample.Decrypt(txt, bytesPlainTextKey);

            textBox4.Text = Decrypted;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var txt = Text_txt.Text;
            var plainTextData = EncKey_txt.Text;

            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

            var encrypted = TripleDESSample.Encrypt(txt, bytesPlainTextData);

            textBox4.Text = encrypted;
        }
    }
}
