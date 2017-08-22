using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhooingTransactionMaker.DataModels
{
    public class InvokeResult<T>
    {
        /*
         * "code" : 200,
			"message" : "",
			"error_parameters" : {},
			"rest_of_api" : 4988,
			"results" : {
				"user_id" : 27,
				"username" : "Helloman",
				"last_ip" : "192.168.0.1",
				"last_login_timestamp" : 1322448931,
				"created_timestamp" : 1321448931,
				"modified_timestamp" : 1321448931,
				"language" : "ko",
				"level" : "1",
				"expire" : 1321448931,
				"timezone" : "Asia/Seoul",
				"currency" : "KRW",
				"country" : "KR",
				"image_url" : "https://s3-ap-northeast-1.amazonaws.com/whooingprofile/p27.jpg",
				"mileage" : 230
			}
		}
         */

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("rest_of_api")]
        public int RemainNumberofAPIUse { get; set; }

        [JsonProperty("results")]
        public T Results { get; set; }
    }
}
