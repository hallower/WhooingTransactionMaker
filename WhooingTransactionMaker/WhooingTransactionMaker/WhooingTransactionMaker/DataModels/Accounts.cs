using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.DataModels
{
    public class Accounts
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

        [JsonProperty("assets")]
        public ICollection<AccountData> Assets { get; set; }

        [JsonProperty("liabilities")]
        public ICollection<AccountData> Liabilities { get; set; }

        [JsonProperty("capital")]
        public ICollection<AccountData> Capitals { get; set; }

        [JsonProperty("income")]
        public ICollection<AccountData> Incomes { get; set; }

        [JsonProperty("expenses")]
        public ICollection<AccountData> Expenses { get; set; }
    }
}
