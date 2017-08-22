using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.DataModels
{
    public class Entries
    {
        /*
         "results" : {
		"reports" : [],
		"rows" : [
			{
				"entry_id" : 1352827,
				"entry_date" : 20110817.0001,
				"l_account" : "expenses",
				"l_account_id" : "x20",
				"r_account" : "assets",
				"r_account_id" : "x4",
				"item" : "후원(과장학금)",
				"money" : 10000,
				"total" : 840721.99
				"memo" : "",
				"app_id" : 0
			},
			{
				"entry_id" : 1352823,
				"entry_date" : 20110813.0001,
				"l_account" : "assets",
				"l_account_id" : "x3",
				"r_account" : "assets",
				"r_account_id" : "x4",
				"item" : "계좌이체",
				"money" : 10000,
				"total" : 840721.99
				"memo" : "",
				"app_id" : 0
			}
		]
	}*/
        [JsonProperty("rows")]
        public ICollection<EntryData> EntryList { get; set; } = new List<EntryData>();
    }
}
