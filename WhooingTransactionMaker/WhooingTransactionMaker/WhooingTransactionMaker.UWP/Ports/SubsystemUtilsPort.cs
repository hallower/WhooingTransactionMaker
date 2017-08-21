using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.UWP.Ports;
using WhooingTransactionMaker.Helpers;
using Windows.UI.Xaml;

[assembly: Xamarin.Forms.Dependency(typeof(ISubsystemUtils))]
namespace WhooingTransactionMaker.UWP.Ports
{
    public class SubsystemUtilsPort : ISubsystemUtils
    {
        public string GetSHA1Hash(string key)
        {
            if (key.Length < 1)
            {
                return string.Empty;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            return sha1.ComputeHash(keyBytes).ToString();
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
