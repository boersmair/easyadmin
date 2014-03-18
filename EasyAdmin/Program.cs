using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
namespace EasyAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG

#else
            LoginForm li = new LoginForm();
            if (li.ShowDialog() == DialogResult.Cancel)
                return;

            
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();
            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(li.psw));
            //create new instance of StringBuilder to save hashed data
            StringBuilder hs = new StringBuilder();
            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                hs.Append(hashData[i].ToString());
            }
            string hss = hs.ToString();

            /*string hs;
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.Default.GetBytes(li.psw));
                hs = System.Text.Encoding.Unicode.GetString(hash);
            }*/

            /*byte[] data = new byte[DATA_SIZE];
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(;
            */
           // if (hss != "5572122962710262291002341402512391832792419657121")
           //     return;
            if (hss != "17420018621713091625920221721721887252529291166100113")
                return;
            
#endif
            Application.Run(new FormMain());
        }
    }
}
