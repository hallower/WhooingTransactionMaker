using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.DataModels
{
    public class AccountData
    {
        /*
{
	"code" : 200,
	"message" : "",
	"error_parameters" : {},
	"rest_of_api" : 4988,
	"results" : {
		"assets" : [
			{
				"account_id" : "x1",
				"type" : "group",
				"title" : "유동자산",
				"memo" : "바로쓸 수 있는 것들",
				"open_date" : 20090511,
				"close_date" : 20160101,
				"category" : "",
			},
			{
				"account_id" : "x2",
				"type" : "account",
				"title" : "현금",
				"memo" : "내 지갑 및 서랍에 있는 돈",
				"open_date" : 20090511,
				"close_date" : 20160101,
				"category" : "normal",
			}
		],
		"liabilities" : [
			{
				"account_id" : "x10",
				"type" : "account",
				"title" : "신한카드",
				"memo" : "월 목표 사용액 : 50만원",
				"open_date" : 20110101,
				"close_date" : 21000101,
				"category" : "creditcard",
				"opt_use_date" : "p1",
				"opt_pay_date" : 25,
				"opt_pay_account_id" : "x1"
			}
		],
		"capital" : [
			{
				"account_id" : "x8",
				"type" : "account",
				"title" : "초기설정",
				"memo" : "기초자금 설정 및 자본수정",
				"open_date" : 20100101,
				"close_date" : 20100101,
				"cetegory" : ""
			}
		],
		"income" : [
			{
				"account_id" : "x21",
				"type" : "account",
				"title" : "주수익",
				"memo" : "월급 및 기타소득",
				"open_date" : 20010101,
				"close_date" : 21000101,
				"category" : "steady"
			}
		],
		"expenses" : [
			{
				"account_id" : "x23",
				"type" : "account",
				"title" : "식비",
				"memo" : "일반 생활식비",
				"open_date" : 20010101,
				"close_date" : 21000101,
				"category" : "steady"
			}
		]	
	}
}        */

        [JsonProperty("account_id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("open_date")]
        public string OpenDate { get; set; }

        [JsonProperty("close_date")]
        public string CloseDate { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
