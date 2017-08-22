using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WhooingTransactionMaker.Droid.Ports;
using WhooingTransactionMaker.Helpers;
using Android.Util;

[assembly: Xamarin.Forms.Dependency(typeof(SubsystemUtilsPort))]
namespace WhooingTransactionMaker.Droid.Ports
{
    public class SubsystemUtilsPort : ISubsystemUtils
    {
        private static string TAG = "csk";

        public SubsystemUtilsPort() { }

        public void Dbg(string message)
        {
            Log.Debug(TAG, message);
        }

        public void Err(string message)
        {
            Log.Error(TAG, message);
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
            foreach (var b in hash)
            {
                int tmp = (b & 0xff) + 0x100;
                result += tmp.ToString("x").Substring(1);
            }
            //return Encoding.UTF8.GetString(hash);
            return result;
        }

        public void TerminateApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        public void Toast(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, "click", ToastLength.Long).Show();
        }
    }
}