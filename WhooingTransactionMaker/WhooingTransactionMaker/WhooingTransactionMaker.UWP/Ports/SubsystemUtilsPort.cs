using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.UWP.Ports;
using WhooingTransactionMaker.Helpers;
using Windows.UI.Xaml;

[assembly: Xamarin.Forms.Dependency(typeof(SubsystemUtilsPort))]
namespace WhooingTransactionMaker.UWP.Ports
{
    public class SubsystemUtilsPort : ISubsystemUtils
    {
        public SubsystemUtilsPort()
        {

        }

        public string GetSHA1Hash(string key)
        {
            if (key.Length < 1)
            {
                return string.Empty;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] hash = sha1.ComputeHash(keyBytes);

            string result = string.Empty;
            foreach(var b in hash)
            {
                int tmp = (b & 0xff) + 0x100;
                result += tmp.ToString("x").Substring(1);
            }
            //return Encoding.UTF8.GetString(hash);
            return result;
        }

        public void Dbg(string message)
        {

        }

        public void Err(string message)
        {

        }
        public void Toast(string message)
        {

        }

        public void TerminateApp()
        {
            Application.Current.Exit();
        }
    }
}
