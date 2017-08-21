using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.Helpers
{
    public interface ISubsystemUtils
    {
        string GetSHA1Hash(string key);

        void Dbg(string message);

        void Err(string message);

        void Toast(string message);

        void TerminateApp();
    }
}
