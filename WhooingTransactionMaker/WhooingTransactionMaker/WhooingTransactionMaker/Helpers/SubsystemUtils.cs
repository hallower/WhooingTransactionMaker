using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhooingTransactionMaker.Helpers
{
    public sealed class SubsystemUtils : ISubsystemUtils
    {
        private static readonly Lazy<SubsystemUtils> lazy =
            new Lazy<SubsystemUtils>(() => new SubsystemUtils());

        public static SubsystemUtils Instance { get { return lazy.Value; } }

        private ISubsystemUtils systemUtils;

        class DefaultSubsystemUtils : ISubsystemUtils
        {
            public string GetSHA1Hash(string key)
            {
                return string.Empty;
            }

            public void Dbg(string message) { }
            public void Err(string message) { }            
            public void Toast(string message) { }
            public void TerminateApp() { }
        }

        private SubsystemUtils()
        {
            try
            {
                if (DependencyService.Get<ISubsystemUtils>() != null)
                {
                    systemUtils = DependencyService.Get<ISubsystemUtils>();
                }
                else
                {
                    systemUtils = new DefaultSubsystemUtils();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Oops DefaultSubsystemUtils initiation failed, " + e.Message);
                systemUtils = new DefaultSubsystemUtils();
            }
        }

        public string GetSHA1Hash(string key)
        {
            return systemUtils.GetSHA1Hash(key);
        }

        public void Dbg(string message)
        {
            systemUtils.Dbg(message);
        }

        public void Err(string message)
        {
            systemUtils.Err(message);
        }

        public void Toast(string message)
        {
            systemUtils.Toast(message);
        }

        public void TerminateApp()
        {
            systemUtils.TerminateApp();
        }
    }
}
