using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.DataModels;

namespace WhooingTransactionMaker.Models
{
    public sealed class AccountProvider
    {
        private static readonly string urlAccounts = "https://whooing.com/api/accounts.json_array";

        public Accounts AllAccounts { get; private set; }

        public AccountProvider()
        {
        }

        public async Task<Accounts> ReadAll(string sectionID)
        {
            var uri = urlAccounts + "?section_id=" + sectionID;
            var result = await RESTInvoker.Invoke<Accounts>(RestMethod.GET, uri, string.Empty);
            if (result == null ||
                result.Results == null)
            {
                return null;
            }

            AllAccounts = result.Results;
            return result.Results;
        }
    }
}
