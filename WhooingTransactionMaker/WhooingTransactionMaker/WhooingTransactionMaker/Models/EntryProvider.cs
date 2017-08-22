using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.DataModels;

namespace WhooingTransactionMaker.Models
{
    public class EntryProvider
    {
        private static readonly string urlReadEntries = "/api/entries.json";
        
        // TODO : add parameters
        public static async Task<Entries> Read(string sectionID)
        {
            /*
             {
	"code" : 200,
	"message" : "",
	"error_parameters" : {},
	"rest_of_api" : 4988,
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
	}
}            */

            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-20);
                
            var uri = $"{urlReadEntries}?section_id={sectionID}&start_date={startDate.ToString("yyyyMMdd")}&end_date={endDate.ToString("yyyyMMdd")}";

            var result = await RESTInvoker.Invoke<Entries>(RestMethod.GET, uri, string.Empty);
            if (result == null ||
                result.Results == null)
            {
                return new Entries();
            }

            return result.Results;
        }
    }
}
