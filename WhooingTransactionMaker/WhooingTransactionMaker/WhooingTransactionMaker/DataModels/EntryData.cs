using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.DataModels
{
    public class EntryData
    {
        /*
         {
			"entry_id" : 1352827,
			"entry_date" : 20110812.0001,
			"l_account" : "expenses",
			"l_account_id" : "x20",
			"r_account" : "assets",
			"r_account_id" : "x4",
			"item" : "후원(과장학금)",
			"money" : 10000,
			"total" : "",
			"memo" : "오늘도 어김없이 빠져나갔다",
			"app_id" : 0
		},
         */
        [JsonProperty("entry_id")]
        public string ID { get; set; }

        [JsonProperty("entry_date")]
        public string Date { get; set; }

        [JsonProperty("l_account")]
        public string LeftAccount { get; set; }

        [JsonProperty("l_account_id")]
        public string LeftAccountID { get; set; }

        [JsonProperty("r_account")]
        public string RightAccount { get; set; }

        [JsonProperty("r_account_id")]
        public string RightAccountID { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("money")]
        public string Money { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }
    }
}
