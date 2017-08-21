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
using WhooingTransactionMaker.Helpers;
using Android.Util;

[assembly: Xamarin.Forms.Dependency(typeof(ISubsystemUtils))]
namespace WhooingTransactionMaker.Droid.Ports
{
    public class SubsystemUtilsPort : ISubsystemUtils
    {
        private static string TAG = "csk";

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
            return sha1.ComputeHash(keyBytes).ToString();
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