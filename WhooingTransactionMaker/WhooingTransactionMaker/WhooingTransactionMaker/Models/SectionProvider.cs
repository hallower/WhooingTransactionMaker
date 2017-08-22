using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhooingTransactionMaker.DataModels;

namespace WhooingTransactionMaker.Models
{
    public sealed class SectionProvider
    {
        private static readonly string urlReadSections = "/api/sections.json_array";
        private static readonly string urlReadDefaultSections = "/api/sections/default.json";

        public SectionProvider()
        {

        }

        private SectionData defaultSection;
        public SectionData DefaultSection
        {
            get => defaultSection;
            set => defaultSection = value;
        }

        public async Task<string> SetDefaultSection()
        {
            DefaultSection = await ReadDefaultSections();
            return DefaultSection.ID;
        }

        public async Task<SectionData> ReadDefaultSections()
        {
            /*
            {
   "code" : 200,
   "error" : "",
   "rest_of_api" : 2388,
   "results" : {
       "section_id" : "s123",
       "title" : "유동성 자산",
       "memo" : "자주접근하는 자산만 관리",
       "currency" : "KRW",
       "isolation" : "n",
       "total_assets" : 2982799.00,
       "total_liabilities" : 23910.00,
       "skin_id" : 2,
       "decimal_places" : 2,
       "date_format" : "YMD"		
   }
}             */
            var result = await RESTInvoker.Invoke<SectionData>(RestMethod.GET, urlReadDefaultSections, string.Empty);
            if (result == null ||
                result.Results == null)
            {
                return null;
            }

            return result.Results;
        }

        public async Task<ICollection<SectionData>> ReadSections()
        {
            /*
{
	"code" : 200,
	"message" : "",
	"error_parameters" : {},
	"rest_of_api" : 4988,
	"results" : [
		{
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
		{
			"section_id" : "s283",
			"title" : "부동자산",
			"memo" : "규모가 큰 자산들",
			"currency" : "KRW",
			"isolation" : "n",
			"total_assets" : 1929882838.00,
			"total_liabilities" : 2328862.00,
			"skin_id" : 1,
			"decimal_places" : 2,
			"date_format" : "YMD"
		},	
	]
}         */
            var result = await RESTInvoker.Invoke<ICollection<SectionData>>(RestMethod.GET, urlReadSections, string.Empty);
            if (result == null ||
                result.Results == null)
            {
                return null;
            }

            return result.Results;
        }
    }
}
