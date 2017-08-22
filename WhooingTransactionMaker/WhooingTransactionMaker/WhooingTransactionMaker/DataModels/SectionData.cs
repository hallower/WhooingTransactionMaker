using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.Helpers;

namespace WhooingTransactionMaker.DataModels
{
    public class SectionData
    {
        /*
         * s123" : {
			"section_id" : "s123",
			"title" : "유동성 자산",
			"memo" : "자주접근하는 자산만 관리",
			"currency" : "KRW",
			"isolation" : "n",
			"total_assets" : 2982799.00,
			"total_liabilities" : 23910.00,
			"skin_id" : 0,
			"decimal_places" : 2,
			"date_format" : "YMD"
		},
         */

        [JsonProperty("section_id")]
        public string ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("isolation")]
        public bool IsHidden { get; set; }
     
    }
}
