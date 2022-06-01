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

namespace Bob
{
    public partial class Form1 : Form
    {
        static TripleDESCryptoServiceProvider ttdes = new TripleDESCryptoServiceProvider();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  var pubKey;
            //Get Public Key from file
            string readText = File.ReadAllText("PublicK.csr");
           
                var sr = new System.IO.StringReader(readText);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                var pubKey = (RSAParameters)xs.Deserialize(sr);


            //new CSP(cryptographic service provider)
            var  csp = new RSACryptoServiceProvider();
            csp.ImportParameters(pubKey);
            var plainTextData = EncKey_txt.Text;

            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //base64
            var cypherText = Convert.ToBase64String(bytesCypherText);
            Encrypted_txt.Text = cypherText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var txt = Text_txt.Text;
            var plainTextData = EncKey_txt.Text;

            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainTextData);

            var encrypted = TripleDESSample.Encrypt(txt, bytesPlainTextData);

            textBox4.Text = encrypted;
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


    }
}
